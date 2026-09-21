@echo off
setlocal EnableExtensions DisableDelayedExpansion
title Publish ASPRunner.NET project to GitHub

rem Usage:
rem   publish-runnerapps-to-github.bat
rem   publish-runnerapps-to-github.bat "C:\runnerapps\1Form3"

set "PROJECT_DIR=%~1"
if not defined PROJECT_DIR set "PROJECT_DIR=C:\runnerapps\1Form3"

echo.
echo === ASPRunner.NET project to GitHub ===
echo Project folder: "%PROJECT_DIR%"
echo.

where git >nul 2>nul
if errorlevel 1 (
    echo ERROR: Git for Windows is not installed or is not in PATH.
    echo Install it from https://git-scm.com/download/win, then run this file again.
    pause
    exit /b 1
)

if not exist "%PROJECT_DIR%\" (
    echo ERROR: The project folder does not exist:
    echo "%PROJECT_DIR%"
    pause
    exit /b 1
)

cd /d "%PROJECT_DIR%" || (
    echo ERROR: Could not open the project folder.
    pause
    exit /b 1
)

rem Set a local Git identity only if one has not already been configured.
git config user.name >nul 2>nul
if errorlevel 1 call :configure_name
if errorlevel 1 exit /b 1

git config user.email >nul 2>nul
if errorlevel 1 call :configure_email
if errorlevel 1 exit /b 1

if not exist ".git" (
    echo Initializing the local Git repository...
    git init
    if errorlevel 1 goto :git_error
)

git remote get-url origin >nul 2>nul
if errorlevel 1 goto :no_remote
call :maybe_change_remote
if errorlevel 1 goto :git_error
goto :remote_ready

:no_remote
call :add_remote
if errorlevel 1 goto :git_error

:remote_ready

echo.
echo Staging project files...
git add -A
if errorlevel 1 goto :git_error

git diff --cached --quiet
if errorlevel 1 goto :commit_changes
echo There are no new changes to commit.
goto :commit_ready

:commit_changes
call :commit_staged_changes
if errorlevel 1 goto :git_error

:commit_ready

echo.
echo Pushing to GitHub...
git branch -M main
git push -u origin main
if errorlevel 1 (
    echo.
    echo Push failed. Confirm that the GitHub repository is empty and that you signed in.
    echo GitHub may open a browser for authentication, or require a personal access token.
    pause
    exit /b 1
)

echo.
echo SUCCESS: "%PROJECT_DIR%" is now under Git version control and pushed to GitHub.
echo You can select this same folder in ASPRunner.NET Version Control Settings.
pause
exit /b 0

:git_error
echo.
echo ERROR: Git reported a problem. Review the message above and run the file again.
pause
exit /b 1

:configure_name
set /p "GIT_NAME=Enter the name to show on Git commits: "
if not defined GIT_NAME goto :missing_name
git config user.name "%GIT_NAME%"
exit /b %errorlevel%

:missing_name
echo ERROR: A commit author name is required.
pause
exit /b 1

:configure_email
set /p "GIT_EMAIL=Enter the email to show on Git commits: "
if not defined GIT_EMAIL goto :missing_email
git config user.email "%GIT_EMAIL%"
exit /b %errorlevel%

:missing_email
echo ERROR: A commit author email is required.
pause
exit /b 1

:add_remote
echo.
echo Create a NEW EMPTY repository on GitHub first.
echo Do not add a README, .gitignore, or license on GitHub.
echo.
set /p "REPO_URL=Paste the repository HTTPS URL, then press Enter: "
if not defined REPO_URL goto :missing_url
git remote add origin "%REPO_URL%"
exit /b %errorlevel%

:maybe_change_remote
for /f "delims=" %%R in ('git remote get-url origin') do set "EXISTING_URL=%%R"
echo Existing GitHub remote: %EXISTING_URL%
set /p "CHANGE_REMOTE=Change it? Type Y then Enter to change, or press Enter to keep it: "
if /i not "%CHANGE_REMOTE%"=="Y" exit /b 0
set /p "REPO_URL=Paste the replacement repository HTTPS URL: "
if not defined REPO_URL goto :missing_url
git remote set-url origin "%REPO_URL%"
exit /b %errorlevel%

:missing_url
echo ERROR: A GitHub repository URL is required.
pause
exit /b 1

:commit_staged_changes
set /p "COMMIT_MESSAGE=Commit message [Initial commit]: "
if not defined COMMIT_MESSAGE set "COMMIT_MESSAGE=Initial commit"
git commit -m "%COMMIT_MESSAGE%"
exit /b %errorlevel%

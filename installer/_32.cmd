set TO_GO_TO=%*
%TO_GO_TO:~0,2%
cd "%TO_GO_TO%"

@ECHO OFF

SET DESTINATION_DIR=%LocalAppData%\emotion-recognition\dist
SET DEPEDENCY_SOURCE_DIR=bin

SET LIB_MODS_DIR=%DEPEDENCY_SOURCE_DIR%\lib-mods
SET PYTHON_INSTALLER_DIR=%DEPEDENCY_SOURCE_DIR%
SET GRAPHIZ_DIR=%DEPEDENCY_SOURCE_DIR%\graphviz-2.38

SET PYTHON_INSTALLER=%PYTHON_INSTALLER_DIR%\python-3.6.6.exe

SET PYTHON_INSTALLATION_DIR=%LocalAppData%\Programs\Python\Python36
SET PYTHON_EXECUTABLE_PATH=%PYTHON_INSTALLATION_DIR%
SET GRAPHIZ_INSTALLATION_DIR=%DESTINATION_DIR%\graphviz
SET GRAPHIZ_EXECUTABLE_PATH=%GRAPHIZ_INSTALLATION_DIR%\bin
SET RUN_APP_EXEC_BIN=%DEPEDENCY_SOURCE_DIR%\Emotion recognition.cmd
SET RUN_APP_EXEC_DEST=%DESTINATION_DIR%\Emotion recognition.cmd
SET RUN_APP_DESKTOP_DEST=%USERPROFILE%\Desktop\Emotion recognition.cmd

SET EMOPY_PATH=%PYTHON_INSTALLATION_DIR%\Lib\site-packages\EmoPy
SET APP_DIR=%DEPEDENCY_SOURCE_DIR%\app
SET APP_INSTALLATION_DIR=%DESTINATION_DIR%\app

SET MODEL_DESTINATION_DIR=%USERPROFILE%\Desktop\Emotion recognition model
SET MODEL_SOURCE_DIR=%DEPEDENCY_SOURCE_DIR%\model

ECHO UNARCHIVING THE INSTALLATOR
"%DEPEDENCY_SOURCE_DIR%\7z\7za" x "%DEPEDENCY_SOURCE_DIR%\bin.zip" -y -o"%DEPEDENCY_SOURCE_DIR%"  >nul 2>&1

ECHO UNINSTALLING LOCAL PYTHON 3.6.6
"%PYTHON_INSTALLER%" /uninstall /quiet  >nul 2>&1

ECHO PREPARING LOCAL USER INSTALLATION DIRECTORY

DEL /F/Q/S "%DESTINATION_DIR%"  >nul 2>&1
RMDIR /Q/S "%DESTINATION_DIR%"  >nul 2>&1
MKDIR "%DESTINATION_DIR%"
MKDIR "%GRAPHIZ_INSTALLATION_DIR%"

ECHO INSTALLING APPLICATION DEPENDENCIES

XCOPY /Y/E/H/I "%GRAPHIZ_DIR%" "%GRAPHIZ_INSTALLATION_DIR%"  >nul 2>&1
XCOPY /Y/E/H/I "%APP_DIR%" "%APP_INSTALLATION_DIR%"  >nul 2>&1

ECHO INSTALLINIG APPLICATION USER PYTHON 3.6.6
"%PYTHON_INSTALLER%" /quiet PrependPath=0 InstallAllUsers=0 Include_launcher=0 Include_test=0 SimpleInstall=1  >nul 2>&1

ECHO UPGRADING LOCAL USER PYTHON DEPENDENCIES
"%PYTHON_EXECUTABLE_PATH%\python" -m pip install EmoPy  >nul 2>&1
"%PYTHON_EXECUTABLE_PATH%\python" -m pip install -U numpy  >nul 2>&1
"%PYTHON_EXECUTABLE_PATH%\python" -m pip install -U encodings  >nul 2>&1

ECHO PATCHING PYTHON SOURCES

XCOPY /Y/E/H/I "%LIB_MODS_DIR%" "%EMOPY_PATH%\examples"  >nul 2>&1
DEL /F/Q/S "%EMOPY_PATH%\examples\fermodel.py"  >nul 2>&1
XCOPY /Y/E/H/I "%LIB_MODS_DIR%\fermodel.py" "%EMOPY_PATH%\src"  >nul 2>&1

ECHO CREATING RUN SHORTCUT

COPY /Y "%RUN_APP_EXEC_BIN%" "%RUN_APP_EXEC_DEST%"  >nul 2>&1
COPY /Y "%RUN_APP_EXEC_BIN%" "%RUN_APP_DESKTOP_DEST%"  >nul 2>&1


ECHO CREATING MODEL FOLDER AT "%MODEL_DESTINATION_DIR%"

RMDIR /Q/S "%MODEL_DESTINATION_DIR%"
MKDIR "%MODEL_DESTINATION_DIR%"
XCOPY /Y/E/H/I "%MODEL_SOURCE_DIR%" "%MODEL_DESTINATION_DIR%"  >nul 2>&1

ECHO CLEARUP

DEL /F/Q/S "%PYTHON_INSTALLER_DIR%\python-3.6*" >nul 2>&1
DEL /F/Q/S "%GRAPHIZ_DIR%"  >nul 2>&1
DEL /F/Q/S "%LIB_MODS_DIR%"  >nul 2>&1
DEL /F/Q/S "%APP_DIR%"  >nul 2>&1
DEL /F/Q/S "%RUN_APP_EXEC_BIN%"  >nul 2>&1
DEL /F/Q/S "%MODEL_SOURCE_DIR%" >nul 2>&1

RMDIR /Q/S "%GRAPHIZ_DIR%"  >nul 2>&1
RMDIR /Q/S "%LIB_MODS_DIR%"  >nul 2>&1
RMDIR /Q/S "%APP_DIR%"  >nul 2>&1
RMDIR /Q/S "%MODEL_SOURCE_DIR%"  >nul 2>&1

ECHO INSTALLATION HAS BEEN COMPLETED SUCCESSFULLY
PAUSE

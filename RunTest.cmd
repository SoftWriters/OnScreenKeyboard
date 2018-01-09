@echo OFF
echo.
IF NOT EXIST bin\ (
    echo Please run PublishBin.cmd before running the test.
) else (
    echo Input:
    echo.
    cat data\TestData.txt
    echo.
    echo.
    echo Output:
    echo.
    cat data\TestData.txt | bin\MapToKeyboardInput.exe
)
echo.



"%Unity%Unity.exe" -runTests -projectPath %cd% -testResults results.xml -testPlatform playmode

extent -i results.xml -o results/

python uploadReport.py
from pydrive.auth import GoogleAuth
from pydrive.drive import GoogleDrive

gauth = GoogleAuth()
gauth.LocalWebserverAuth()
gauth.SaveCredentialsFile("creds.txt")
drive = GoogleDrive(gauth)

#TODO
# Make the folder dynamic based on date/time and upload the report to the newly-created folder in drive
folderCreate = drive.CreateFile({'title': 'UnityTestReports', "mimeType": "application/vnd.google-apps.folder"})
folderCreate.Upload()

folder = drive.ListFile({'q': "title = 'UnityTestReports' and trashed=false"}).GetList()[0] # get the folder we just created
indexFile = drive.CreateFile({'parents': [{'id': folder['id']}]})
indexFile.SetContentFile('results/index.html')
indexFile.Upload()

dashboardFile = drive.CreateFile({'parents': [{'id': folder['id']}]})
dashboardFile.SetContentFile('results/dashboard.html')
dashboardFile.Upload()

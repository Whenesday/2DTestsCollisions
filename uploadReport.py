from pydrive.auth import GoogleAuth
from pydrive.drive import GoogleDrive
import datetime

gauth = GoogleAuth()
gauth.LocalWebserverAuth()
gauth.SaveCredentialsFile("creds.txt")
drive = GoogleDrive(gauth)
now = datetime.datetime.now().strftime("%Y-%m-%d")

title = "UnityTestReports-"+now
folderCreate = drive.CreateFile({'title': title, "mimeType": "application/vnd.google-apps.folder"})
folderCreate.Upload()

folders = drive.ListFile({'q': "title='" + title + "' and mimeType='application/vnd.google-apps.folder' and trashed=false"}).GetList()
for folder in folders:
	if folder['title'] == title:
		indexFile = drive.CreateFile({'parents': [{'id': folder['id']}]})
		indexFile.SetContentFile('results/index.html')
		indexFile.Upload()
		dashboardFile = drive.CreateFile({'parents': [{'id': folder['id']}]})
		dashboardFile.SetContentFile('results/dashboard.html')
		dashboardFile.Upload()
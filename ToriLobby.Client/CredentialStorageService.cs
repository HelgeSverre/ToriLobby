using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace ToriLobby.Client
{
    class CredentialStorageService
    {
        private readonly string _fileStorePath;
        private List<Credentials> _accounts;


        // TODO: Add a default path in user appdata or something
        public CredentialStorageService(string fileStoragePath)
        {

            if (!File.Exists(fileStoragePath))
            {
                File.Create(fileStoragePath);
            }

            _fileStorePath = fileStoragePath;
        }


        public void Load(bool flushExisting = true)
        {
            List<Credentials> temp = new List<Credentials>();
            StreamReader reader = new StreamReader(_fileStorePath);


            // Loop through the credential store file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Match credentialMatch = Regex.Match(line, @"(\w+):(\w+)");
                var user = credentialMatch.Groups[0].Captures[0].ToString();
                var pass = credentialMatch.Groups[0].Captures[1].ToString();

                temp.Add(new Credentials(user, pass));
            }

            // Flush the account list if we were told to
            if (flushExisting)
                _accounts = new List<Credentials>();

            // Add each temporary account into the _accounts list
            foreach (Credentials credentials in temp)
            {
                _accounts.Add(credentials);
            }
        }

        public void Store()
        {
            StringBuilder credentialFileStoreContents = new StringBuilder();

            foreach (Credentials account in _accounts)
            {
                credentialFileStoreContents.AppendLine($"{account.Username}:{account.Password}");
            }

            StreamWriter writer = new StreamWriter(_fileStorePath);

            writer.Write(credentialFileStoreContents);
            writer.Flush();
            writer.Close();
        }
    }
}

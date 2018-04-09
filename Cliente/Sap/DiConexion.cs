using System;
//using SAPbobsCOM;

namespace MigracionSap.Cliente.Sap
{


    public class Company
    {
        public string Server { get; set; } = "";
        public string LicenseServer { get; set; } = "";
        public string CompanyDB { get; set; } = "";
        public int DbServerType { get; set; } = 6; //SQL SERVER 2008
        public string DbUserName { get; set; } = "";
        public string DbPassword { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public int language { get; set; } = 0;
    }

    public class DiConexion : IDisposable
    {

        public string Server = "";
        private string LicenseServer = "";
        public string CompanyDB = "";
        public string DbUserName = "";
        public string DbPassword = "";
        private string UserName = "";
        private string Password = "";

        public Company oCompany = null;
        public bool disposed = false;

        /// <summary>
        /// Construction
        /// </summary>
        public DiConexion(string server, string licenseServer, string companyDB, 
                        string dbUserName, string dbPassword, string userName, 
                        string password)
        {

            this.Server = server;
            this.LicenseServer = licenseServer;
            this.CompanyDB = companyDB;
            this.DbUserName = dbUserName;
            this.DbPassword = dbPassword;
            this.UserName = userName;
            this.Password = password;

            this.Conectar();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~DiConexion()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherithed from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                    this.Desconectar();
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }

        public bool Conectar()
        {
            bool flag = false;
            try
            {
                /*
                this.oCompany = new Company();

                oCompany.Server = this.Server;
                oCompany.LicenseServer = this.LicenseServer;
                oCompany.CompanyDB = this.CompanyDB;
                oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                oCompany.DbUserName = this.DbUserName;
                oCompany.DbPassword = this.DbPassword;
                oCompany.UserName = this.UserName;
                oCompany.Password = this.Password;
                oCompany.language = BoSuppLangs.ln_Spanish_La;

                int retCode = oCompany.Connect();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception($"SBO : {codErr} - {msgErr}");
                }
                else
                {
                    flag = true;
                }
                */
                System.Threading.Thread.Sleep(2000);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Desconectar()
        {
            bool flag = false;
            try
            {
                if (this.oCompany == null)
                    flag = true;
                /*
                if (this.oCompany.Connected == true)
                { 
                    this.oCompany.Disconnect();
                    flag = true;
                }
                */

                System.Threading.Thread.Sleep(2000);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

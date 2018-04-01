using System;
using SAPbobsCOM;

namespace MigracionSap.Simple.Sap
{
    public class DiConexion : IDisposable
    {

        public Company oCompany = null;
        public bool disposed = false;

        /// <summary>
        /// Construction
        /// </summary>
        public DiConexion()
        {
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
                this.oCompany = new Company();

                oCompany.Server = "SRVMAYO1";
                oCompany.LicenseServer = "192.168.1.10:30000";
                oCompany.CompanyDB = "SBO_PRUEBACMAYO19072017";
                oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                oCompany.DbUserName = "sa";
                oCompany.DbPassword = "Sapb1admin";
                oCompany.UserName = "manager";
                oCompany.Password = "m1r1";
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

                if (this.oCompany.Connected == true)
                { 
                    this.oCompany.Disconnect();
                    flag = true;
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

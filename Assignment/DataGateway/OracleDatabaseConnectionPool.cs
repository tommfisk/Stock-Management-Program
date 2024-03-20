using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataGateway
{
    // Object Pool Design Pattern (10 connections available - needs extra for tests)
    public class OracleDatabaseConnectionPool
    {
        private static string DATABASE_USERNAME = "F012028L";
        private static string DATABASE_PASSWORD = "F012028L";

        private static OracleDatabaseConnectionPool instance = new OracleDatabaseConnectionPool(10);

        private List<OracleConnection> availableConnections;
        private List<OracleConnection> busyConnections;

        public static OracleDatabaseConnectionPool GetInstance()
        {
            return instance;
        }

        private OracleDatabaseConnectionPool(int sizeOfPool)
        {
            availableConnections = new List<OracleConnection>(sizeOfPool);
            busyConnections = new List<OracleConnection>(sizeOfPool);

            if (DATABASE_USERNAME == null || DATABASE_USERNAME.Equals(""))
            {
                LoadDatabaseCredentialsFromFile();
            }

            for (int i = 0; i < sizeOfPool; i++)
            {
                availableConnections.Add(CreateOracleConnection());
            }
        }

        ~OracleDatabaseConnectionPool()
        {
            foreach (OracleConnection conn in availableConnections)
            {
                CloseOracleConnection(conn);
            }
            availableConnections.Clear();

            foreach (OracleConnection conn in busyConnections)
            {
                CloseOracleConnection(conn);
            }
            busyConnections.Clear();
        }

        public OracleConnection AcquireConnection()
        {
            if (availableConnections.Count > 0)
            {
                OracleConnection conn = availableConnections[0];
                availableConnections.RemoveAt(0);
                busyConnections.Add(conn);
                return conn;
            }

            return null;
        }

        private void CloseOracleConnection(OracleConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: closure of database connection failed", e);
                }
            }
        }

        private OracleConnection CreateOracleConnection()
        {
            string DB_CONNECTION_STRING
                = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = vmp3wstuoradb1.staff.staffs.ac.uk)(PORT = 1521))"
                    + "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = STORAPDB.staff.staffs.ac.uk)));User Id=" + DATABASE_USERNAME + ";Password=" + DATABASE_PASSWORD + ";";

            OracleConnection conn = null;

            try
            {
                conn = new OracleConnection(DB_CONNECTION_STRING);
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: connection to database failed", e);
            }

            return conn;
        }

        private void LoadDatabaseCredentialsFromFile()
        {
            Console.Write("Oracle database username: > ");
            DATABASE_USERNAME = Console.ReadLine();
            Console.Write("Oracle database_ password: > ");
            DATABASE_PASSWORD = Console.ReadLine();

            //FileInfo dbCredsFile = new FileInfo("db_creds.txt");
            //FileStream dbCredsStream = dbCredsFile.OpenRead();
            //StreamReader dbCredsReader = new StreamReader(dbCredsStream);

            //dbCredsReader.ReadLine(); //disregard comment line

            //string[] parts = dbCredsReader.ReadLine().Split(':'); //read credentials line
            //DATABASE_USERNAME = parts[0];
            //DATABASE_PASSWORD = parts[1];

            //dbCredsReader.Close();
        }

        public void ReleaseConnection(OracleConnection conn)
        {
            if (busyConnections.Contains(conn))
            {
                busyConnections.Remove(conn);
                availableConnections.Add(conn);
            }
        }
    }
}

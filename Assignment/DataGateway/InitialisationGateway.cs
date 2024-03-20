using DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;

namespace DataGateway
{
    public class InitialisationGateway : OracleDatabaseGateway
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        private OracleCommand createEmployeeSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE Employee_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand createEmployeeTable = new OracleCommand
        {
            CommandText = "CREATE TABLE Employee(id number primary key, employee_name varchar2(20) not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand createItemSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE Item_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand createItemTable = new OracleCommand
        {
            CommandText = "CREATE TABLE Item(id number primary key, item_name varchar2(20) not null, quantity number not null, price binary_double not null, date_created TIMESTAMP not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand createTransactionSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE Transaction_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand createTransactionTable = new OracleCommand
        {
            CommandText = "CREATE TABLE Transaction(id number primary key, type varchar2(20) not null, item_id number not null CONSTRAINT item_FK REFERENCES Item(id), employee_id number not null CONSTRAINT employee_FK REFERENCES Employee(id), quantity number not null, date_created TIMESTAMP not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand dropItemSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE Item_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand dropItemTable = new OracleCommand
        {
            CommandText = "DROP TABLE Item",
            CommandType = CommandType.Text
        };

        private OracleCommand dropEmployeeSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE Employee_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand dropEmployeeTable = new OracleCommand
        {
            CommandText = "DROP TABLE Employee",
            CommandType = CommandType.Text
        };

        private OracleCommand dropTransactionSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE Transaction_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand dropTransactionTable = new OracleCommand
        {
            CommandText = "DROP TABLE Transaction",
            CommandType = CommandType.Text
        };

        private List<OracleCommand> commandSequence;

        public InitialisationGateway()
        {
            commandSequence = new List<OracleCommand>()
            {
                dropTransactionTable,
                dropTransactionSeq,

                dropItemTable,
                dropItemSeq,

                dropEmployeeTable,
                dropEmployeeSeq,

                createItemTable,
                createItemSeq,

                createEmployeeTable,
                createEmployeeSeq,

                createTransactionTable,
                createTransactionSeq
            };
        }

        public void InitialiseOracleDatabase()
        {
            OracleConnection conn = GetOracleConnection();

            foreach (OracleCommand c in commandSequence)
            {
                try
                {
                    c.Connection = conn;
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: SQL command failed\n" + e.StackTrace, e);
                }
            }

            dataGatewayFacade.AddEmployee(new EmployeeDTO("Graham"));
            dataGatewayFacade.AddEmployee(new EmployeeDTO("Phil"));
            dataGatewayFacade.AddEmployee(new EmployeeDTO("Jan"));


            dataGatewayFacade.AddItem(new ItemDTO("pen", 10, 2.50));
            dataGatewayFacade.AddTransaction(new TransactionDTO("Item Added", 1, 1, 10));

            dataGatewayFacade.AddItem(new ItemDTO("eraser", 20, 3.50));
            dataGatewayFacade.AddTransaction(new TransactionDTO("Item Added", 2, 2, 20));

            dataGatewayFacade.TakeQuantityFromItem(1, 4);
            dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Taken", 1, 1, 4));

            dataGatewayFacade.AddQuantityToItem(2, 2);
            dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Added", 2, 2, 2));

            CloseOracleConnection(conn);
        }
    }
}

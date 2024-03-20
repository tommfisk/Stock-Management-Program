using Assignment.DataGateway;
using DTO;
using Library;
using System;
using System.Collections.Generic;

namespace DataGateway
{
    public sealed class DataGatewayFacade
    {
        // Singleton Design Pattern (only one instance of class at any given time)
        // Facade Design Pattern

        private static readonly InitialisationGateway initialisationGateway = new InitialisationGateway();
        private static DataGatewayFacade instance = null;
        private static readonly DTO_Converter converter = new DTO_Converter();

        private DataGatewayFacade()
        {
        }

        public static DataGatewayFacade getInstance()
        {
            if (instance == null)
            {
                instance = new DataGatewayFacade();
            }
            return instance;
        }

        public void InitialiseOracleDatabase()
        {
            initialisationGateway.InitialiseOracleDatabase();
        }

        public int AddItem(ItemDTO itemDTO)
        {
            Item item = converter.Convert(itemDTO);
            return new InsertItem(item).Insert();
        }

        public int AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = converter.Convert(employeeDTO);
            return new InsertEmployee(employee).Insert();
        }

        public int AddTransaction(TransactionDTO transactionDTO)
        {
            Transaction transaction = converter.Convert(transactionDTO);
            return new InsertTransaction(transaction).Insert();
        }

        public int AddQuantityToItem(int id, int quantity)
        {
            return new AddQuantityToItem(id, quantity).Update();
        }

        public int TakeQuantityFromItem(int id, int quantity)
        {
            return new TakeQuantityFromItem(id, quantity).Update();
        }

        public ItemDTO FindItemById(int id)
        {
            return converter.Convert(new FindItemById(id).Select());
        }

        public ItemDTO FindItemByName(string name)
        {
            return converter.Convert(new FindItemByName(name).Select());
        }

        public EmployeeDTO FindEmployeeById(int id)
        {
            return converter.Convert(new FindEmployeeById(id).Select());
        }

        public EmployeeDTO FindEmployeeByName(string name)
        {
            return converter.Convert(new FindEmployeeByName(name).Select());
        }

        public TransactionDTO FindTransaction(int id)
        {
            return converter.Convert(new FindTransaction(id).Select());
        }

        public List<ItemDTO> GetAllItems()
        {
            List<Item> items = new GetAllItems().Select();
            List<ItemDTO> itemDTOs = new List<ItemDTO>();

            foreach (Item item in items)
            {
                itemDTOs.Add(converter.Convert(item));
            }

            return itemDTOs;
        }

        public List<TransactionDTO> GetAllTransactions()
        {
            
            List<Transaction> transactions = new GetAllTransactions().Select();
            List<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
            
            foreach (Transaction entry in transactions)
            {
                transactionDTOs.Add(converter.Convert(entry));
            }

            return transactionDTOs;
        }


    }
}

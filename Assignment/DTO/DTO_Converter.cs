using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace DTO
{
    // DTO Design Pattern
    public class DTO_Converter
    {
        public Transaction Convert(TransactionDTO dto)
        {
            return
                new Transaction(
                    dto.ID,
                    dto.Type,
                    dto.Item_ID,
                    dto.Employee_ID,
                    dto.Quantity,
                    dto.Date_Created
                    );
        }

        public TransactionDTO Convert(Transaction transaction)
        {
            if (transaction == null)
            {
                return null;
            }

            return
                new TransactionDTO(
                    transaction.ID,
                    transaction.Type,
                    transaction.Item_ID,
                    transaction.Employee_ID,
                    transaction.Quantity,
                    transaction.Date_Created
                    );
        }

        public Employee Convert(EmployeeDTO dto)
        {
            return
                new Employee(
                    dto.ID,
                    dto.Employee_Name
                    );
        }

        public EmployeeDTO Convert(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            return
                new EmployeeDTO(
                    employee.ID,
                    employee.Employee_Name
                    );
        }

        public Item Convert(ItemDTO dto)
        {
            return
                new Item(
                    dto.ID,
                    dto.Item_Name,
                    dto.Quantity,
                    dto.Price,
                    dto.Date_Created
                    );
        }

        public ItemDTO Convert(Item item)
        {
            if (item == null)
            {
                return null;
            }

            return
                new ItemDTO(
                    item.ID,
                    item.Item_Name,
                    item.Quantity,
                    item.Price,
                    item.Date_Created
                    );
        }
    }
}

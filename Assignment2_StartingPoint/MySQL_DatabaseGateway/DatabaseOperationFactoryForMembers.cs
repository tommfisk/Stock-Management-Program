using Entities;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class DatabaseOperationFactoryForMembers
    {
        public const int SELECT_ALL = 1;
        public const int SELECT_BY_ID = 2;

        public DatabaseInserter<Member> CreateInserter()
        {
            return new InsertMember();
        }

        public ISelector<List<Member>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetAllMembers();
            }
            return new NullSelector<List<Member>>();
        }

        public ISelector<Member> CreateSelector(int typeOfSelection, int i)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_ID:
                    return new FindMemberById(i);
                default:
                    return new NullSelector<Member>();
            }
        }
    }
}

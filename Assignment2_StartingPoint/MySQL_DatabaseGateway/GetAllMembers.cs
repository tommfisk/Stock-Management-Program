using Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllMembers : DatabaseSelector<List<Member>>
    {

        public GetAllMembers()
        {
        }

        protected override string GetSQL()
        {
            return "SELECT ID, Name FROM SDAM_Member";
        }

        protected override List<Member> DoSelect(MySqlCommand command)
        {
            List<Member> members = new List<Member>();

            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Member member =
                        new MemberBuilder()
                            .WithId(dr.GetInt32(0))
                            .WithName(dr.GetString(1))
                            .Build();
                    members.Add(member);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of members failed", e);
            }

            return members;
        }
    }
}

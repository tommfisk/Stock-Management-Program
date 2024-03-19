using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class FindMemberById : DatabaseSelector<Member>
    {

        private int memberId;

        public FindMemberById(int memberId)
        {
            this.memberId = memberId;
        }

        protected override string GetSQL()
        {
            return "SELECT ID, Name FROM SDAM_Member WHERE id = @MemberId";
        }

        protected override Member DoSelect(MySqlCommand command)
        {
            Member member = null;

            try
            {
                command.Parameters.AddWithValue("@MemberId", memberId);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    member =
                        new MemberBuilder()
                            .WithId(dr.GetInt32(0))
                            .WithName(dr.GetString(1))
                            .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of member failed", e);
            }

            return member;
        }
    }
}

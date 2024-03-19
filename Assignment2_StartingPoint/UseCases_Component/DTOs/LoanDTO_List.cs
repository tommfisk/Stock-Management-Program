using System.Collections.Generic;

namespace DTOs
{

    [Serializable]
    public class LoanDTO_List : IDto
    {
        public List<LoanDTO> List { get; }

        public LoanDTO_List(List<LoanDTO> list)
        {
            List = list;
        }
    }
}

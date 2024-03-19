using DTOs;
using System.Collections.Generic;
using UseCase;

namespace CommandLineUI.Presenters
{
    class AllMembersPresenter : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<MemberDTO> members = ((MemberDTO_List)DataToPresent).List;
                List<string> lines = new List<string>(members.Count + 2);
                lines.Add("\nAll members");
                lines.Add(string.Format("\t{0, -4} {1}", "ID", "Name"));

                members.ForEach(m => lines.Add(DisplayMember(m)));

                return new CommandLineViewData(lines);
            }
        }

        private string DisplayMember(MemberDTO m)
        {
            return string.Format(
                "\t{0, -4} {1}",
                m.ID,
                m.Name);
        }
    }
}

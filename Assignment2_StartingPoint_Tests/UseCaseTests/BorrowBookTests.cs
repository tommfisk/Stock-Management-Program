using DTOs;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UseCase;

namespace UseCasesTests
{
    [TestClass]
    public class BorrowBookTests
    {
        [TestMethod]
        public void Test_WhenBookIsNotFound_ExpectMessageBookNotFound()
        {
            Mock<IDatabaseGatewayFacade> gatewayMock = new Mock<IDatabaseGatewayFacade>();
            gatewayMock.Setup(gw => gw.FindBook(It.IsAny<int>())).Returns((Book)null);
            gatewayMock.Setup(gw => gw.FindMember(It.IsAny<int>())).Returns((Member)null);

            BorrowBook_UseCase useCase = new BorrowBook_UseCase(1, 12, gatewayMock.Object);

            Assert.AreEqual("Book not found", ((MessageDTO)useCase.Execute()).Message);
        }

        [TestMethod]
        public void Test_WhenMemberIsNotFound_ExpectMessageMemberNotFound()
        {
            BookBuilder bookBuilder = new BookBuilder();

            Mock<IDatabaseGatewayFacade> gatewayMock = new Mock<IDatabaseGatewayFacade>();
            gatewayMock.Setup(gw => gw.FindBook(It.IsAny<int>())).Returns(bookBuilder.Build());
            gatewayMock.Setup(gw => gw.FindMember(It.IsAny<int>())).Returns((Member)null);

            BorrowBook_UseCase useCase = new BorrowBook_UseCase(1, 12, gatewayMock.Object);

            Assert.AreEqual("Member not found", ((MessageDTO)useCase.Execute()).Message);
        }

        [TestMethod]
        public void Test_WhenBookBorrowReturnsTrue_ExpectMessageBookBorrowed()
        {
            BookBuilder bookBuilder = new BookBuilder();
            Book book = bookBuilder.WithState("Available").Build();

            MemberBuilder memberBuilder = new MemberBuilder();
            Member member = memberBuilder.Build();

            Mock<IDatabaseGatewayFacade> gatewayMock = new Mock<IDatabaseGatewayFacade>();
            gatewayMock.Setup(gw => gw.FindBook(It.IsAny<int>())).Returns(book);
            gatewayMock.Setup(gw => gw.FindMember(It.IsAny<int>())).Returns(member);

            BorrowBook_UseCase useCase = new BorrowBook_UseCase(1, 12, gatewayMock.Object);

            Assert.AreEqual("Book borrowed", ((MessageDTO)useCase.Execute()).Message);
        }

        [TestMethod]
        public void Test_WhenBookBorrowReturnsFalse_ExpectMessageBookNotBorrowed()
        {
            BookBuilder bookBuilder = new BookBuilder();
            Book book = bookBuilder.WithState("On loan").Build();

            MemberBuilder memberBuilder = new MemberBuilder();
            Member member = memberBuilder.Build();

            Mock<IDatabaseGatewayFacade> gatewayMock = new Mock<IDatabaseGatewayFacade>();
            gatewayMock.Setup(gw => gw.FindBook(It.IsAny<int>())).Returns(book);
            gatewayMock.Setup(gw => gw.FindMember(It.IsAny<int>())).Returns(member);

            BorrowBook_UseCase useCase = new BorrowBook_UseCase(1, 12, gatewayMock.Object);

            Assert.AreEqual("Book not borrowed", ((MessageDTO)useCase.Execute()).Message);
        }
    }
}

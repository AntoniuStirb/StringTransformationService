using Microsoft.VisualStudio.TestTools.UnitTesting;
using appDevnest;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string input_example = "full_name, email, location\nAntoniu, antoniu@mail.com, Romania\nAndrei, andrei.a@yahoo.com, Belgium\nAndrei, andrei.a@yahoo.com, Belgium\nAlexandru, alex.al@gmail.com, Romania\nRares, rares.pop@mail.com, Spain\nHoratiu, horatiu.horatiu@mail.com, Cluj";
            string output_example = "A:\nAntoniu, antoniu@mail.com, Romania\nAndrei, andrei.a@yahoo.com, Belgium\nAlexandru, alex.al@gmail.com, Romania\n\nR:\nRares, rares.pop@mail.com, Spain\n\nH:\nHoratiu, horatiu.horatiu@mail.com, Cluj\n";
            //Act
            string methodOutput = PersonInfo.Solver(input_example);
            //Assert
            Assert.IsTrue(output_example.Equals(methodOutput));
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            string input_example = "full_name, email, location\nMaria, mariaa@mail.com, Bucuresti\nAlin, alin@mail.com, Constanta\nAlin, alin@mail.com, Constanta\nSergiu, sergiu@yahoo.com, Brasov\nIonut, ionutpop@mail.com, Sibiu\nDaniel, daniel@mail.com, Iasi";
            string output_example = "M:\nMaria, mariaa@mail.com, Bucuresti\n\nA:\nAlin, alin@mail.com, Constanta\n\nS:\nSergiu, sergiu@yahoo.com, Brasov\n\nI:\nIonut, ionutpop@mail.com, Sibiu\n\nD:\nDaniel, daniel@mail.com, Iasi\n";
            //Act
            string methodOutput = PersonInfo.Solver(input_example);
            //Assert
            Assert.IsTrue(output_example.Equals(methodOutput));
        }
        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            string input_example = "full_name, email, location\nRadu, radu.radu@gmail.com, Zalau\nMihai, mihai@yahoo.com, Mures\nDan, dan@mail.com, Baia Mare\nRadu, radu.radu@gmail.com, Zalau\nAlexandru, alexandrupop@gmail.com, Satu Mare\nAlina, alinaa@mail.com, Timis\nDan, dan@mail.com, Baia Mare";
            string output_example = "R:\nRadu, radu.radu@gmail.com, Zalau\n\nM:\nMihai, mihai@yahoo.com, Mures\n\nD:\nDan, dan@mail.com, Baia Mare\n\nA:\nAlexandru, alexandrupop@gmail.com, Satu Mare\nAlina, alinaa@mail.com, Timis\n";
            //Act
            string methodOutput = PersonInfo.Solver(input_example);
            //Assert
            Assert.IsTrue(output_example.Equals(methodOutput));
        }



    }
}

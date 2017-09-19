using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BPD.FACTA.Procesor;
using BPD.FACTA.Interfaces;
using Moq;


namespace BPD.FACTA.Test
{
    public class FACTAProcesorTest
    {

        [Fact]
        public void Throws_ArgumentNullException_With_Null_IFACTADataProvider()
        {
            //Arrange
            var mockFACTADataProvider = new Moq.Mock<IFACTADataProvider>();            
            var mockFACTAParser = new Moq.Mock<IFACTAParser>();
            var mockFACTAFileGenerator = new Moq.Mock<IFACTAFileGenerator>();

            //ACT

            //Assert
            Assert.Throws<ArgumentNullException>(() => new FACTAProcesor(mockFACTADataProvider.Object, mockFACTAParser.Object, mockFACTAFileGenerator.Object));


        }


    }
}

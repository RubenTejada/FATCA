using System;
using Xunit;
using Moq;
using BPD.FACTA.Interfaces;
using BPD.FACTA.Domain;
using BPD.FACTA.Procesor;


 
    public class FACTAProcesorTest
    {
        [Fact]
        public void Throw_ArgumentNullException_On_IFACTADataProvider_Null_Constructor()
        {
            //Arrange            
            var mockFACTAParser = new Mock<IFACTAParser>();
            var mockFACTAFileGenerator = new Mock<IFACTAFileGenerator>();            

            //Assert
            Assert.Throws<ArgumentNullException>(() => new FACTAProcesor(null, mockFACTAParser.Object, mockFACTAFileGenerator.Object));
            
        }

    [Fact]
    public void Throw_ArgumentNullException_On_IFACTAParser_Null_Constructor()
    {
        //Arrange
        var mockDataProvider = new Mock<IFACTADataProvider>();        
        var mockFACTAFileGenerator = new Mock<IFACTAFileGenerator>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new FACTAProcesor(mockDataProvider.Object, null , mockFACTAFileGenerator.Object));

    }


    [Fact]
    public void Throw_ArgumentNullException_On_IFACTAFileGenerator_Null_Constructor()
    {
        //Arrange
        var mockDataProvider = new Mock<IFACTADataProvider>();
        var mockFACTAParser = new Mock<IFACTAParser>();        

        //Assert
        Assert.Throws<ArgumentNullException>(() => new FACTAProcesor(mockDataProvider.Object, mockFACTAParser.Object, null));

    }


}


using System;
using Xunit;
using Moq;
using BPD.FATCA.Interfaces;

using BPD.FATCA.Procesor;


 
    public class FATCAProcesorTest
    {
        [Fact]
        public void Throw_ArgumentNullException_On_IFATCADataProvider_Null_Constructor()
        {
            //Arrange            
            var mockFATCAParser = new Mock<IFATCAParser>();
            var mockFATCAFileGenerator = new Mock<IFATCAFileGenerator>();            

            //Assert
           // Assert.Throws<ArgumentNullException>(() => new FATCAProcesor(null, mockFATCAParser.Object, mockFATCAFileGenerator.Object));
            
        }

    [Fact]
    public void Throw_ArgumentNullException_On_IFATCAParser_Null_Constructor()
    {
        //Arrange
        var mockDataProvider = new Mock<IFATCADataProvider>();        
        var mockFATCAFileGenerator = new Mock<IFATCAFileGenerator>();

        //Assert
       // Assert.Throws<ArgumentNullException>(() => new FATCAProcesor(mockDataProvider.Object, null , mockFATCAFileGenerator.Object));

    }


    [Fact]
    public void Throw_ArgumentNullException_On_IFATCAFileGenerator_Null_Constructor()
    {
        //Arrange
        var mockDataProvider = new Mock<IFATCADataProvider>();
        var mockFATCAParser = new Mock<IFATCAParser>(); 

        //Assert 
       // Assert.Throws<ArgumentNullException>(() => new FATCAProcesor(mockDataProvider.Object, mockFATCAParser.Object, null));

    }


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

using BPD.FATCA.Interfaces;
using BPD.FATCA.Procesor;


public class SimpleFATCAParserTest
{

    [Fact]
    public void Throw_ArgumentNullException_On_IFATCAParser_Null_Constructor()
    {
        //Arrange
        var mockFATCAValidator = new Mock<IFATCAValidator>();
        var mockFATCAMapper = new Mock<IFATCAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFATCAParser(null, mockFATCAMapper.Object));

    }


    [Fact]
    public void Throw_ArgumentNullException_On_IFATCAMapper_Null_Constructor()
    {
        //Arrange
        var mockFATCAValidator = new Mock<IFATCAValidator>();
        var mockFATCAMapper = new Mock<IFATCAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFATCAParser(mockFATCAValidator.Object, null));

    }


    [Fact]
    public void Method_ParseData_Must_Return_Same_Count()
    {
        //Arrange
        var mockFATCAValidator = new Mock<IFATCAValidator>();
        var mockFATCAMapper = new Mock<IFATCAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFATCAParser(mockFATCAValidator.Object, null));

    }

    [Theory]
    [MemberData("FATCAData")]
    public void Method_ParseData_Must_Return_Same_Count(List<string> FATCAData)
    {

        //Arrange
        var mockFATCAValidator = new Mock<IFATCAValidator>();
        mockFATCAValidator.Setup(v => v.Validate(new string[] { "a", "b", "c", "d", "e" })).Returns(true);

        var mockFATCAMapper = new Mock<IFATCAMapper>();
       // mockFATCAMapper.Setup(m => m.Map(new string[] { "a", "b", "c", "d", "e" })).Returns(new FATCARecord());
        var sut = new SimpleFATCAParser(mockFATCAValidator.Object, mockFATCAMapper.Object);

        var result = sut.ParseData(FATCAData);

        //Assert.Equal(FATCAData.Count, result.Count());
    }

    public static IEnumerable<object[]> FATCAData()
    {
        yield return new object[] {
            new List<string>()
            {
            "a,b,c,d,e",
            "a,b,c,d,e",
            "a,b,c,d,e"
            }
            
        };
    }


}


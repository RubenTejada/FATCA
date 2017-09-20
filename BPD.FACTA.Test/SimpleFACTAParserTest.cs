using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using BPD.FACTA.Domain;
using BPD.FACTA.Interfaces;
using BPD.FACTA.Procesor;


public class SimpleFACTAParserTest
{

    [Fact]
    public void Throw_ArgumentNullException_On_IFACTAParser_Null_Constructor()
    {
        //Arrange
        var mockFACTAValidator = new Mock<IFACTAValidator>();
        var mockFACTAMapper = new Mock<IFACTAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFACTAParser(null, mockFACTAMapper.Object));

    }


    [Fact]
    public void Throw_ArgumentNullException_On_IFACTAMapper_Null_Constructor()
    {
        //Arrange
        var mockFACTAValidator = new Mock<IFACTAValidator>();
        var mockFACTAMapper = new Mock<IFACTAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFACTAParser(mockFACTAValidator.Object, null));

    }


    [Fact]
    public void Method_ParseData_Must_Return_Same_Count()
    {
        //Arrange
        var mockFACTAValidator = new Mock<IFACTAValidator>();
        var mockFACTAMapper = new Mock<IFACTAMapper>();

        //Assert
        Assert.Throws<ArgumentNullException>(() => new SimpleFACTAParser(mockFACTAValidator.Object, null));

    }

    [Theory]
    [MemberData("FACTAData")]
    public void Method_ParseData_Must_Return_Same_Count(List<string> FACTAData)
    {

        //Arrange
        var mockFACTAValidator = new Mock<IFACTAValidator>();
        mockFACTAValidator.Setup(v => v.Validate(new string[] { "a", "b", "c", "d", "e" })).Returns(true);

        var mockFACTAMapper = new Mock<IFACTAMapper>();
        mockFACTAMapper.Setup(m => m.Map(new string[] { "a", "b", "c", "d", "e" })).Returns(new FACTARecord());
        var sut = new SimpleFACTAParser(mockFACTAValidator.Object, mockFACTAMapper.Object);

        var result = sut.ParseData(FACTAData);

        Assert.Equal(FACTAData.Count, result.Count());
    }

    public static IEnumerable<object[]> FACTAData()
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


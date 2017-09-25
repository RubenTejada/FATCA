using BPD.FATCA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BPD.FATCA.Procesor
{
    public class SimpleFATCAMapper : IFATCAMapper
    {
        public void Map(string[] FATCAData, ref FATCA_OECD FATCAObj)
        {
            //Mapeo de Version columna 0
            FATCAObj.version = "2.0";// FATCAData[0];  //TODO: mover a configuracion


            //MessageSpec
            if (ColumnsContainsData(FATCAData, CoulumnRange(1, 10)) && FATCAObj.MessageSpec==null)
            {
                FATCAObj.MessageSpec = new MessageSpec_Type()
                {
                    SendingCompanyIN = FATCAData[1],
                    TransmittingCountry = ParseEnum<CountryCode_Type>(FATCAData[2]), //Validar enum
                    ReceivingCountry = ParseEnum<CountryCode_Type>(FATCAData[3]), //Validar enum
                    MessageType = ParseEnum<MessageType_EnumType>(FATCAData[4]),//Validar enum
                    Warning = FATCAData[5],
                    Contact = FATCAData[6],
                    MessageRefId = FATCAData[7],
                    CorrMessageRefId = new string[] { FATCAData[8] },
                    ReportingPeriod = ParseDate(FATCAData[9]),  //Validate DateTime
                    Timestamp = ParseDate(FATCAData[10]), //Validate DateTime
                };
            }

            if(FATCAObj.FATCA==null || FATCAObj.FATCA.Length==0)
                FATCAObj.FATCA = new Fatca_Type[] { new Fatca_Type() };

            Fatca_Type CurrentFacta = FATCAObj.FATCA[0];

            //ReportingFI
            if (ColumnsContainsData(FATCAData, CoulumnRange(11, 32)) && CurrentFacta.ReportingFI==null)
            {
                CurrentFacta.ReportingFI = new CorrectableReportOrganisation_Type();
                CurrentFacta.ReportingFI.ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[11]);

                //TIN
                if (ColumnsContainsData(FATCAData, new int[] { 12, 13 }))
                {
                    CurrentFacta.ReportingFI.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[12],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[13]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[13])
                    } };

                    
                }

                //Name
                if (ColumnsContainsData(FATCAData, new int[] { 14, 15 }))
                {
                    CurrentFacta.ReportingFI.Name = new NameOrganisation_Type[] {new NameOrganisation_Type()
                    {
                        Value=FATCAData[14],
                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[15])
                    } };
                }

                //Address
                if (ColumnsContainsData(FATCAData, new int[] { 16, 17, 18 }))
                {
                    CurrentFacta.ReportingFI.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[16]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[17]),
                       Items=new string[]{ FATCAData[18] }                      
                    } };

                    //AddressFix
                    if (ColumnsContainsData(FATCAData, CoulumnRange(19, 27)))
                    {
                       var AddressFix = new AddressFix_Type()
                        {
                            Street = FATCAData[19],
                            BuildingIdentifier = FATCAData[20],
                            SuiteIdentifier = FATCAData[21],
                            FloorIdentifier = FATCAData[22],
                            DistrictName = FATCAData[23],
                            POB = FATCAData[24],
                            PostCode = FATCAData[25],
                            City = FATCAData[26],
                            CountrySubentity = FATCAData[27],
                        };

                        CurrentFacta.ReportingFI.Address[0].Items = AppendToArray<object>(CurrentFacta.ReportingFI.Address[0].Items, AddressFix, true);
                    }

                }

                //DocSpec
                CurrentFacta.ReportingFI.FilerCategory = ParseEnum<FatcaFilerCategory_EnumType>(FATCAData[28]);

                if (ColumnsContainsData(FATCAData, CoulumnRange(29, 32)))
                {
                    CurrentFacta.ReportingFI.DocSpec = new DocSpec_Type()
                    {
                        DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[29]),
                        DocRefId = FATCAData[30],
                        CorrMessageRefId = FATCAData[31],
                        CorrDocRefId = FATCAData[32],
                    };
                }
            }


            //ReportingGroup

            if (CurrentFacta.ReportingGroup == null || CurrentFacta.ReportingGroup.Length == 0)
                CurrentFacta.ReportingGroup = new Fatca_TypeReportingGroup[] { new Fatca_TypeReportingGroup() };
            Fatca_TypeReportingGroup currentReportingGroup = CurrentFacta.ReportingGroup[0];

            if (ColumnsContainsData(FATCAData, CoulumnRange(33, 213)))
            {
                //Sponsor
                if (ColumnsContainsData(FATCAData, CoulumnRange(33, 54)))
                {

                    currentReportingGroup.Sponsor = new CorrectableReportOrganisation_Type()
                    {
                        ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[33])
                    };

                    //TIN
                    if (ColumnsContainsData(FATCAData, new int[] { 34, 35 }))
                    {
                        currentReportingGroup.Sponsor.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[34],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[35]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[35])
                    } };                       
                    }

                    //Name
                    if (ColumnsContainsData(FATCAData, new int[] { 36, 37 }))
                    {
                        currentReportingGroup.Sponsor.Name = new NameOrganisation_Type[] {new NameOrganisation_Type()
                    {
                        Value=FATCAData[36],
                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[37])
                    } };
                    }

                    //Address
                    if (ColumnsContainsData(FATCAData, new int[] { 38, 39, 40 }))
                    {
                        currentReportingGroup.Sponsor.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[38]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[39]),
                       Items=new string[]{ FATCAData[40] }                      
                    } };

                        //AddressFix
                        if (ColumnsContainsData(FATCAData, CoulumnRange(41, 49)))
                        {
                            var AddressFix = new AddressFix_Type()
                            {
                                Street = FATCAData[41],
                                BuildingIdentifier = FATCAData[42],
                                SuiteIdentifier = FATCAData[43],
                                FloorIdentifier = FATCAData[44],
                                DistrictName = FATCAData[45],
                                POB = FATCAData[46],
                                PostCode = FATCAData[47],
                                City = FATCAData[48],
                                CountrySubentity = FATCAData[49],
                            };

                            currentReportingGroup.Sponsor.Address[0].Items = AppendToArray<object>(currentReportingGroup.Sponsor.Address[0].Items, AddressFix, true);
                        }

                    }

                    //DocSpec
                    currentReportingGroup.Sponsor.FilerCategory = ParseEnum<FatcaFilerCategory_EnumType>(FATCAData[50]);

                    if (ColumnsContainsData(FATCAData, CoulumnRange(51, 54)))
                    {
                        currentReportingGroup.Sponsor.DocSpec = new DocSpec_Type()
                        {
                            DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[51]),
                            DocRefId = FATCAData[52],
                            CorrMessageRefId = FATCAData[53],
                            CorrDocRefId = FATCAData[54],
                        };
                    }
                }

                //Intermediary
                if (ColumnsContainsData(FATCAData, CoulumnRange(55, 76)))
                {

                    currentReportingGroup.Intermediary = new CorrectableReportOrganisation_Type()
                    {
                        ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[55])
                    };

                    //TIN
                    if (ColumnsContainsData(FATCAData, new int[] { 56, 57 }))
                    {
                        currentReportingGroup.Intermediary.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[56],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[57]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[57])
                    } };


                    }

                    //Name
                    if (ColumnsContainsData(FATCAData, new int[] { 58, 59 }))
                    {
                        currentReportingGroup.Intermediary.Name = new NameOrganisation_Type[] {new NameOrganisation_Type()
                    {
                        Value=FATCAData[58],
                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[59])
                    } };
                    }

                    //Address
                    if (ColumnsContainsData(FATCAData, new int[] { 60, 61, 62 }))
                    {
                        currentReportingGroup.Intermediary.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[60]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[61]),
                        Items=new string[]{ FATCAData[62] }                      
                    } };

                        //AddressFix
                        if (ColumnsContainsData(FATCAData, CoulumnRange(63, 71)))
                        {
                            var AddressFix = new AddressFix_Type()
                            {
                                Street = FATCAData[63],
                                BuildingIdentifier = FATCAData[64],
                                SuiteIdentifier = FATCAData[65],
                                FloorIdentifier = FATCAData[66],
                                DistrictName = FATCAData[67],
                                POB = FATCAData[68],
                                PostCode = FATCAData[69],
                                City = FATCAData[70],
                                CountrySubentity = FATCAData[71],
                            };
                            currentReportingGroup.Intermediary.Address[0].Items = AppendToArray<object>(currentReportingGroup.Intermediary.Address[0].Items, AddressFix, true);
                        }

                    }

                    //DocSpec
                    currentReportingGroup.Intermediary.FilerCategory = ParseEnum<FatcaFilerCategory_EnumType>(FATCAData[72]);

                    if (ColumnsContainsData(FATCAData, CoulumnRange(73, 76)))
                    {
                        currentReportingGroup.Sponsor.DocSpec = new DocSpec_Type()
                        {
                            DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[73]),
                            DocRefId = FATCAData[74],
                            CorrMessageRefId = FATCAData[75],
                            CorrDocRefId = FATCAData[76],
                        };
                    }
                }

                //NilReport
                //DocSpec
                if (ColumnsContainsData(FATCAData, CoulumnRange(77, 81)))
                {
                    var NilReport = new CorrectableNilReport_Type();

                    NilReport.DocSpec = new DocSpec_Type()
                    {
                        DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[77]),
                        DocRefId = FATCAData[78],
                        CorrMessageRefId = FATCAData[79],
                        CorrDocRefId = FATCAData[80],
                    };

                    NilReport.NoAccountToReport = FATCAData[81].ToLower();

                    currentReportingGroup.Items = AppendToArray<object>(currentReportingGroup.Items, NilReport);
                }

               

                //AcountReport
                if (ColumnsContainsData(FATCAData, CoulumnRange(82, 204)) && !String.IsNullOrWhiteSpace(FATCAData[86]))//Solo generar si hay cuenta
                {

                
                    CorrectableAccountReport_Type CurrentAccountReport = new CorrectableAccountReport_Type();

                    currentReportingGroup.Items= AppendToArray<object>(currentReportingGroup.Items, CurrentAccountReport);

                    //DocSpec
                    if (ColumnsContainsData(FATCAData, CoulumnRange(82, 85)))
                    {


                        CurrentAccountReport.DocSpec = new DocSpec_Type()
                        {
                            DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[82]),
                            DocRefId = FATCAData[83],
                            CorrMessageRefId = FATCAData[84],
                            CorrDocRefId = FATCAData[85],
                        };
                    }

                    //AccountNumber // Todo lo relacionado con la cuenta se incluye o no si esta el numero de cuenta
                    if (ColumnsContainsData(FATCAData, CoulumnRange(86, 88)))
                    {
                        CurrentAccountReport.AccountNumber = new FIAccountNumber_Type()
                        {
                            Value = FATCAData[86],
                            AcctNumberType = ParseEnum<AcctNumberType_EnumType>(FATCAData[87]),
                        };



                        //AccountClosed
                        CurrentAccountReport.AccountClosed = ParseBool(FATCAData[88]);


                    }

                    

                    //AccountHolder
                    if (ColumnsContainsData(FATCAData, CoulumnRange(89, 141)))
                    {
                        CurrentAccountReport.AccountHolder = new AccountHolder_Type();

                        //Individual
                        if (ColumnsContainsData(FATCAData, CoulumnRange(89, 123)))
                        {
                            var Individual = new PersonParty_Type();
                            CurrentAccountReport.AccountHolder.Items = new object[] { Individual };
                            Individual.ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[89]);

                            //TIN
                            if (ColumnsContainsData(FATCAData, new int[] { 90, 91 }))
                            {
                                Individual.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[90],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[91]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[91])
                    } };
                            }

                            //Name
                            if (ColumnsContainsData(FATCAData, CoulumnRange(92, 105)))
                            {
                                Individual.Name = new NamePerson_Type[] {new NamePerson_Type()
                    {

                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[92]),
                        PrecedingTitle=FATCAData[93],
                        Title=new String[]{FATCAData[94] }
                    } };

                                //FirstName
                                Individual.Name[0].FirstName = new NamePerson_TypeFirstName()
                                {
                                    Value = FATCAData[95],
                                    xnlNameType = NullIfEmpty( FATCAData[96])
                                };


                                //MidleName
                                Individual.Name[0].MiddleName = new NamePerson_TypeMiddleName[] { new NamePerson_TypeMiddleName()
                                {
                                    Value=FATCAData[97],
                                    xnlNameType=NullIfEmpty(FATCAData[98])
                                } };

                                //NamePrefix
                                Individual.Name[0].NamePrefix = new NamePerson_TypeNamePrefix()
                                {
                                    Value = FATCAData[99],
                                    xnlNameType = NullIfEmpty(FATCAData[100])
                                };


                                //LastName
                                Individual.Name[0].LastName = new NamePerson_TypeLastName()
                                {
                                    Value = FATCAData[101],
                                    xnlNameType = NullIfEmpty(FATCAData[102])
                                };

                                Individual.Name[0].GenerationIdentifier = new string[] { FATCAData[103] };
                                Individual.Name[0].Suffix = new string[] { FATCAData[104] };
                                Individual.Name[0].GeneralSuffix = FATCAData[105];

                            };

                            //Address
                            if (ColumnsContainsData(FATCAData, CoulumnRange(106, 117)))
                            {
                                Individual.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[106]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[107]),
                      Items=new string[]{FATCAData[108] }
                    } };

                                //AddressFix
                                if (ColumnsContainsData(FATCAData, CoulumnRange(109, 117)))
                                {
                                    var AddressFix = new AddressFix_Type()
                                    {
                                        Street = FATCAData[109],
                                        BuildingIdentifier = FATCAData[110],
                                        SuiteIdentifier = FATCAData[111],
                                        FloorIdentifier = FATCAData[112],
                                        DistrictName = FATCAData[113],
                                        POB = FATCAData[114],
                                        PostCode = FATCAData[115],
                                        City = FATCAData[116],
                                        CountrySubentity = FATCAData[117],
                                    };

                                    Individual.Address[0].Items = AppendToArray<object>(Individual.Address[0].Items, AddressFix, true);
                                }

                            }

                            //Natioality
                            Individual.Nationality = ParseToEnumArr<CountryCode_Type>(FATCAData[118]);

                            //BirdInfo
                            if (ColumnsContainsData(FATCAData, CoulumnRange(119, 123)))
                            {
                                Individual.BirthInfo = new PersonParty_TypeBirthInfo()
                                {
                                    BirthDate = ParseDate(FATCAData[119]),
                                    City = FATCAData[120],
                                    CitySubentity = FATCAData[121]
                                };

                                //CountryInfo
                                if (ColumnsContainsData(FATCAData, CoulumnRange(122, 123)))
                                {
                                    Individual.BirthInfo.CountryInfo = new PersonParty_TypeBirthInfoCountryInfo();

                                    if (!String.IsNullOrEmpty(FATCAData[122]))
                                        Individual.BirthInfo.CountryInfo.Item = ParseEnum<CountryCode_Type>(FATCAData[122]);
                                    else
                                        Individual.BirthInfo.CountryInfo.Item = FATCAData[123];


                                }
                            }

                        }

                        //Organisation
                        if (ColumnsContainsData(FATCAData, CoulumnRange(124, 140)))
                        {
                            var Organisation = new OrganisationParty_Type();                            
                            CurrentAccountReport.AccountHolder.Items = new object[] { Organisation };

                            Organisation.ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[124]);

                            //TIN
                            if (ColumnsContainsData(FATCAData, new int[] { 125, 126 }))
                            {
                                Organisation.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[125],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[126]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[126])
                    } };
                            }

                            //Name
                            if (ColumnsContainsData(FATCAData, new int[] { 127, 128 }))
                            {
                                Organisation.Name = new NameOrganisation_Type[] {new NameOrganisation_Type()
                    {
                                    Value=FATCAData[127],
                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[128]),
                    } };


                            };

                            //Address
                            if (ColumnsContainsData(FATCAData, CoulumnRange(129, 140)))
                            {
                                Organisation.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[129]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[130]),
                      Items= new string[]{FATCAData[131] }
                    } };

                                //AddressFix
                                if (ColumnsContainsData(FATCAData, CoulumnRange(132, 140)))
                                {
                                    var AddressFix = new AddressFix_Type()
                                    {
                                        Street = FATCAData[132],
                                        BuildingIdentifier = FATCAData[133],
                                        SuiteIdentifier = FATCAData[134],
                                        FloorIdentifier = FATCAData[135],
                                        DistrictName = FATCAData[136],
                                        POB = FATCAData[137],
                                        PostCode = FATCAData[138],
                                        City = FATCAData[139],
                                        CountrySubentity = FATCAData[140],
                                    };

                                    Organisation.Address[0].Items = AppendToArray<object>(Organisation.Address[0].Items, AddressFix, true);
                                }

                            }

                            CurrentAccountReport.AccountHolder.Items = AppendToArray<object>(CurrentAccountReport.AccountHolder.Items, ParseEnum<FatcaAcctHolderType_EnumType>(FATCAData[141]));
                        }                                             

                    }


                    //SubstantialOwner
                    if (ColumnsContainsData(FATCAData, CoulumnRange(142, 193)))
                    {
                        CurrentAccountReport.SubstantialOwner = new SubstantialOwner_Type[] { new SubstantialOwner_Type() };

                        //Individual
                        if (ColumnsContainsData(FATCAData, CoulumnRange(142, 176)))
                        {

                            var Individual = new PersonParty_Type();
                            CurrentAccountReport.SubstantialOwner[0].Item = Individual;
                            Individual.ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[142]);

                            //TIN
                            if (ColumnsContainsData(FATCAData, new int[] { 143, 144 }))
                            {
                                Individual.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[143],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[144]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[144])
                    } };
                            }

                            //Name
                            if (ColumnsContainsData(FATCAData, CoulumnRange(145, 158)))
                            {
                                Individual.Name = new NamePerson_Type[] {new NamePerson_Type()
                    {

                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[145]),
                        PrecedingTitle=FATCAData[146],
                        Title=new String[]{FATCAData[147] }
                    } };

                                //FirstName
                                Individual.Name[0].FirstName = new NamePerson_TypeFirstName()
                                {
                                    Value = FATCAData[148],
                                    xnlNameType = NullIfEmpty(FATCAData[149])
                                };


                                //MidleName
                                Individual.Name[0].MiddleName = new NamePerson_TypeMiddleName[] { new NamePerson_TypeMiddleName()
                                {
                                    Value=FATCAData[150],
                                    xnlNameType=NullIfEmpty(FATCAData[151])
                                } };

                                //NamePrefix
                                Individual.Name[0].NamePrefix = new NamePerson_TypeNamePrefix()
                                {
                                    Value = FATCAData[152],
                                    xnlNameType = NullIfEmpty(FATCAData[153])
                                };


                                //LastName
                                Individual.Name[0].LastName = new NamePerson_TypeLastName()
                                {
                                    Value = FATCAData[154],
                                    xnlNameType = NullIfEmpty(FATCAData[155])
                                };

                                Individual.Name[0].GenerationIdentifier = new string[] { FATCAData[156] };
                                Individual.Name[0].Suffix = new string[] { FATCAData[157] };
                                Individual.Name[0].GeneralSuffix = FATCAData[158];

                            };

                            //Address
                            if (ColumnsContainsData(FATCAData, CoulumnRange(159, 170)))
                            {
                                Individual.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[159]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[160]),
                       Items= new string[]{ FATCAData[161] }                      
                    } };

                                //AddressFix
                                if (ColumnsContainsData(FATCAData, CoulumnRange(162, 170)))
                                {
                                  var AddressFix = new AddressFix_Type()
                                    {
                                        Street = FATCAData[162],
                                        BuildingIdentifier = FATCAData[163],
                                        SuiteIdentifier = FATCAData[164],
                                        FloorIdentifier = FATCAData[165],
                                        DistrictName = FATCAData[166],
                                        POB = FATCAData[167],
                                        PostCode = FATCAData[168],
                                        City = FATCAData[169],
                                        CountrySubentity = FATCAData[170],
                                    };

                                    Individual.Address[0].Items = AppendToArray<object>(Individual.Address[0].Items, AddressFix, true);
                                }

                            }

                            //Natioality
                            Individual.Nationality = ParseToEnumArr<CountryCode_Type>(FATCAData[171]);

                            //BirdInfo
                            if (ColumnsContainsData(FATCAData, CoulumnRange(172, 176)))
                            {
                                Individual.BirthInfo = new PersonParty_TypeBirthInfo()
                                {
                                    BirthDate = ParseDate(FATCAData[172]),
                                    City = FATCAData[173],
                                    CitySubentity = FATCAData[174]
                                };

                                //CountryInfo
                                if (ColumnsContainsData(FATCAData, CoulumnRange(175, 176)))
                                {
                                    Individual.BirthInfo.CountryInfo = new PersonParty_TypeBirthInfoCountryInfo();

                                    if(!String.IsNullOrEmpty(FATCAData[175]))
                                    Individual.BirthInfo.CountryInfo.Item = ParseEnum<CountryCode_Type>(FATCAData[175]);
                                    else
                                    Individual.BirthInfo.CountryInfo.Item = FATCAData[176];
                                        
                                    
                                }
                            }

                        }

                        //Organisation
                        if (ColumnsContainsData(FATCAData, CoulumnRange(177, 193)))
                        {
                           var Organisation = new OrganisationParty_Type();
                           CurrentAccountReport.SubstantialOwner[0].Item =  Organisation;
                           Organisation.ResCountryCode = ParseToEnumArr<CountryCode_Type>(FATCAData[177]);

                            //TIN
                            if (ColumnsContainsData(FATCAData, new int[] { 178, 179 }))
                            {
                                Organisation.TIN = new TIN_Type[]{ new TIN_Type(){
                        Value=FATCAData[178],
                        issuedBy=ParseEnum<CountryCode_Type>(FATCAData[179]),
                        issuedBySpecified= !String.IsNullOrWhiteSpace(FATCAData[179])
                    } };
                            }

                            //Name
                            if (ColumnsContainsData(FATCAData, new int[] { 180, 181 }))
                            {
                                Organisation.Name = new NameOrganisation_Type[] {new NameOrganisation_Type()
                    {
                                    Value=FATCAData[180],
                        nameType=ParseEnum<OECDNameType_EnumType>(FATCAData[181]),
                    } };


                            };

                            //Address
                            if (ColumnsContainsData(FATCAData, CoulumnRange(182, 193)))
                            {
                                Organisation.Address = new Address_Type[] {new Address_Type()
                    {
                       legalAddressType=ParseEnum<OECDLegalAddressType_EnumType>(FATCAData[182]),
                       CountryCode=ParseEnum<CountryCode_Type>(FATCAData[183]),
                       Items= new string[]{ FATCAData[184] }
                    } };

                                //AddressFix
                                if (ColumnsContainsData(FATCAData, CoulumnRange(185, 193)))
                                {
                                    var AddressFix = new AddressFix_Type()
                                    {
                                        Street = FATCAData[185],
                                        BuildingIdentifier = FATCAData[186],
                                        SuiteIdentifier = FATCAData[187],
                                        FloorIdentifier = FATCAData[188],
                                        DistrictName = FATCAData[198],
                                        POB = FATCAData[190],
                                        PostCode = FATCAData[191],
                                        City = FATCAData[192],
                                        CountrySubentity = FATCAData[193],
                                    };

                                    Organisation.Address[0].Items = AppendToArray<object>(Organisation.Address[0].Items, AddressFix, true);
                                }

                            }
                        }

                    }

                    //Account Balance
                    if (ColumnsContainsData(FATCAData, CoulumnRange(194, 195)))
                    {
                        CurrentAccountReport.AccountBalance = new MonAmnt_Type()
                        {
                            Value = ParseDecimal(FATCAData[194]),
                            currCode = ParseEnum<currCode_Type>(FATCAData[195])
                        };
                    }


                    //Payment
                    if (ColumnsContainsData(FATCAData, CoulumnRange(196, 199)))
                    {
                        CurrentAccountReport.Payment = new Payment_Type[]
                        {
                            new Payment_Type()
                        {
                            Type= ParseEnum<FatcaPaymentType_EnumType>(FATCAData[196]),
                            PaymentTypeDesc=FATCAData[197],
                            PaymentAmnt= new MonAmnt_Type()
                            {
                                Value=ParseDecimal( FATCAData[198]),
                                currCode=ParseEnum<currCode_Type>(FATCAData[199])
                            }
                            }
                        };
                    }

                    //CARRef
                    if (ColumnsContainsData(FATCAData, CoulumnRange(200, 202)))
                    {
                        CurrentAccountReport.CARRef = new CARRef_Type()
                        {
                            PoolReportReportingFIGIIN = FATCAData[200],
                            PoolReportMessageRefId = FATCAData[201],
                            PoolReportDocRefId = FATCAData[202]
                        };

                    }

                    //AdditionalData
                    if (ColumnsContainsData(FATCAData, CoulumnRange(203, 204)))
                    {
                        CurrentAccountReport.AdditionalData = new AdditionalData_TypeAdditionalItem[]
                        {
                            new AdditionalData_TypeAdditionalItem()
                            {
                                ItemName=FATCAData[203],
                                ItemContent=FATCAData[204]
                            }
                        };
                    }
                }


                // Pool Report
                //DocSpec
                if (ColumnsContainsData(FATCAData, CoulumnRange(205, 212)))
                {
                    
                    var CurrentPoolReport=new CorrectablePoolReport_Type();

                    currentReportingGroup.Items = AppendToArray<object>(currentReportingGroup.Items, CurrentPoolReport);

                    CurrentPoolReport.DocSpec = new DocSpec_Type()
                    {
                        DocTypeIndic = ParseEnum<FatcaDocTypeIndic_EnumType>(FATCAData[205]),
                        DocRefId = FATCAData[206],
                        CorrMessageRefId = FATCAData[207],
                        CorrDocRefId = FATCAData[208],
                    };

                    CurrentPoolReport.AccountCount = FATCAData[209];
                    CurrentPoolReport.AccountPoolReportType = ParseEnum<FatcaAcctPoolReportType_EnumType>(FATCAData[210]);

                    CurrentPoolReport.PoolBalance = new MonAmnt_Type()
                    {
                        Value=ParseDecimal(FATCAData[211]),
                        currCode=ParseEnum<currCode_Type>(FATCAData[212])
                    };


                }
            }
                

           
            
        }

        private bool ParseBool(string v)
        {
            bool result = false;
            bool.TryParse(v, out result);
            return result;
        }

        private decimal ParseDecimal(string v)
        {
            return Decimal.Parse(v);
        }

        DateTime ParseDate(string datetime)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(datetime, out result);
            return result;
        }

        T ParseEnum<T>(string value)
        {
            if (!String.IsNullOrEmpty(value))
                return (T)Enum.Parse(typeof(T), value);
            else
                return (T)Enum.GetValues(typeof(T)).GetValue(0);
        }

        T[] ParseToEnumArr<T>(string value)
        {
            if (!String.IsNullOrEmpty(value))
                return new T[] { (T)Enum.Parse(typeof(T), value) };
            else
                return new T[] { };
        }

        /// <summary>
        /// Appends a Item to an Array, if the array is null, return an array with the item
        /// </summary>
        /// <typeparam name="T">Type of the Array and item</typeparam>
        /// <param name="currentArr">Array to be use</param>
        /// <param name="item">Item to be added</param>
        /// <returns>Array with the item added</returns>
        T[] AppendToArray<T>(IEnumerable<T> currentArr, T item, bool insertAtBegining=false)
        {
            T[] appendArr = new T[] { item };
            if (currentArr == null)
                return appendArr;
            else
                if(insertAtBegining)
                return appendArr.Concat(currentArr).ToArray();
            else
                return currentArr.Concat(appendArr).ToArray();
        }

       
        IEnumerable<int> CoulumnRange(int from, int to)
        {
            return Enumerable.Range(from, to - from+1);
        }


        String NullIfEmpty(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return null;
            else
                return value;
        }

        

        private  bool ColumnsContainsData(string[] FATCAData,IEnumerable<int> indexes)
        {
            return String.Join(String.Empty, FATCAData.Where((d, i) => indexes.Contains(i))).Length > 0;
        }

        
    }
}

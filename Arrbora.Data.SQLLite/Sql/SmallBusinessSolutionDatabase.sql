#create database SmallBusinessSolution;
#use SmallBusinessSolution;

create database test;
use test;


############################################
### Lookup tables
############################################

#Categories for person - lookup table
create table lkutbl_PersonCategories
(
PersonCategoryID int NOT NULL AUTO_INCREMENT,
PersonCategoryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonCategoryNotes varchar(255),
PRIMARY KEY (PersonCategoryID)
);

#Categories for organizations - lookup table
create table lkutbl_OrganizationCategory
(
OrganizationCategoryID int NOT NULL AUTO_INCREMENT,
OrganizationCategory varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrganizationCategoryNotes varchar(255),
PRIMARY KEY (OrganizationCategoryID)
);

#Organization type - lookup table
create table lkutbl_OrganizationType
(
OrganizationTypeID int NOT NULL AUTO_INCREMENT,
OrganizationCategoryID int,
OrganizationType varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrgPhoneNotes varchar(255),
PRIMARY KEY (OrganizationTypeID),
FOREIGN KEY (OrganizationCategoryID) REFERENCES lkutbl_OrganizationCategory(OrganizationCategoryID)
);

#Address type - lookup table
create table lkutbl_AddressType
(
AddressTypeID int NOT NULL AUTO_INCREMENT,
AddressType varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
AddressTypeNotes varchar(255),
PRIMARY KEY (AddressTypeID)
);

#Role - lookup table
create table lkutbl_RoleDescription
(
RoleID int NOT NULL AUTO_INCREMENT,
RoleName varchar(255),
RoleDescription varchar(255),
RoleInactive bool,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
RoleNotes varchar(255),
PRIMARY KEY (RoleID)
);

#Role - lookup table
create table lkutbl_Role
(
RoleID int NOT NULL AUTO_INCREMENT,
RoleName varchar(255),
RoleDescription varchar(255),
RoleInactive bool,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
RoleNotes varchar(255),
PRIMARY KEY (RoleID)
);

#Title - lookup table
create table lkutbl_Title
(
TitleID int NOT NULL AUTO_INCREMENT,
TitleAbbreviation varchar(255),
TitleDescription varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
TitleNotes varchar(255),
PRIMARY KEY (TitleID)
);

#TitleSuffix - lookup table
create table lkutbl_TitleSuffix
(
TitleSuffixID int NOT NULL AUTO_INCREMENT,
TitleSuffixAbbr varchar(255),
TitleSuffixDesc varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
TitleSuffixNotes varchar(255),
PRIMARY KEY (TitleSuffixID)
);
#Email type - lookup table
create table lkutbl_EmailType
(
EmailTypeID int NOT NULL AUTO_INCREMENT,
EmailType varchar(255),
CountryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
EmailTypeNotes varchar(255),
PRIMARY KEY (EmailTypeID)
);

#State Reference - lookup table
create table lkutbl_StateRef
(
StateRefID int NOT NULL AUTO_INCREMENT,
StateCode varchar(255),
StateName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
StateRefNotes varchar(255),
PRIMARY KEY (StateRefID)
);

#Country Reference - lookup table
create table lkutbl_CountryRef
(
CountryRefID int NOT NULL AUTO_INCREMENT,
CountryAbbreviation varchar(255),
CountryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
CountryRefNotes varchar(255),
PRIMARY KEY (CountryRefID)
);


##################################################
### Main Customer and organization data tables
##################################################

#Person table
create table tbl_Person
(
PersonID int NOT NULL AUTO_INCREMENT,
PersonCode varchar(255),
PersonCategoryID int,
NameLast varchar(255),
NameMiddle varchar(255),
NameFirst varchar(255),
TitleID int,
TitleSuffixID int,
PersonBirthDate date,
PersonDateOfFirstContact varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonNotes varchar(255),
PRIMARY KEY (PersonID),
FOREIGN KEY (PersonCategoryID) REFERENCES lkutbl_PersonCategories(PersonCategoryID),
FOREIGN KEY (TitleID) REFERENCES lkutbl_Title(TitleID),
FOREIGN KEY (TitleSuffixID) REFERENCES lkutbl_TitleSuffix(TitleSuffixID)
);

#Organization table
create table tbl_Organization
(
OrganizationID int NOT NULL AUTO_INCREMENT,
OrganizationName varchar(255),
OrganizationTypeID int,
OrganizationDateOfFirstContact varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrganizationNotes varchar(255),
PRIMARY KEY (OrganizationID),
FOREIGN KEY (OrganizationTypeID) REFERENCES lkutbl_OrganizationType(OrganizationTypeID)
);

#Email table
create table tbl_Email
(
EmailID int NOT NULL AUTO_INCREMENT,
EmailTypeID int,
Email varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
EmailNotes varchar(255),
PRIMARY KEY (EmailID),
FOREIGN KEY (EmailTypeID) REFERENCES lkutbl_EmailType(EmailTypeID)
);

#Phone table
create table tbl_Phone
(
PhoneID int NOT NULL AUTO_INCREMENT,
PhoneType varchar(255),
PhoneCountryCode varchar(255),
PhoneAreaCode varchar(255),
PhonePrefix varchar(255),
PhoneNumber varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PhoneNotes varchar(255),
PRIMARY KEY (PhoneID)
);

#Address table
create table tbl_Address
(
AddressID int NOT NULL AUTO_INCREMENT,
AddressTypeID int,
Addres1 varchar(255),
Addres2 varchar(255),
City varchar(255),
StateRefID int,
PostCode varchar(255),
CountryRefID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
AddressNotes varchar(255),
PRIMARY KEY (AddressID),
FOREIGN KEY (AddressTypeID) REFERENCES lkutbl_AddressType(AddressTypeID),
FOREIGN KEY (StateRefID) REFERENCES lkutbl_StateRef(StateRefID),
FOREIGN KEY (CountryRefID) REFERENCES lkutbl_CountryRef(CountryRefID)
);

##################################################
### Customer and organization junction tables
##################################################

#Email-to-person - junction table
create table jctbl_Email_Person
(
Email_PersonID int NOT NULL AUTO_INCREMENT,
PersonID int,
EmailID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Email_PersonNotes varchar(255),
PRIMARY KEY (Email_PersonID),
FOREIGN KEY (PersonID) REFERENCES tbl_Person(PersonID),
FOREIGN KEY (EmailID) REFERENCES tbl_Email(EmailID)
);

#Person-to-Phone - junction table
create table jctbl_Person_Phone
(
Person_PhoneID int NOT NULL AUTO_INCREMENT,
PhoneID int,
PersonID int,
Person_PhoneDisplayOrder int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Person_PhoneNotes varchar(255),
PRIMARY KEY (Person_PhoneID),
FOREIGN KEY (PhoneID) REFERENCES tbl_Phone(PhoneID),
FOREIGN KEY (PersonID) REFERENCES tbl_Person(PersonID)
);

#Address-to-Person - junction table
create table jctbl_Address_Person
(
Address_PersonID int NOT NULL AUTO_INCREMENT,
PersonID int,
AddressID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Address_PersonNotes varchar(255),
PRIMARY KEY (Address_PersonID),
FOREIGN KEY (PersonID) REFERENCES tbl_Person(PersonID),
FOREIGN KEY (AddressID) REFERENCES tbl_Address(AddressID)
);

#Email-to-Organization - junction table
create table jctbl_Email_Organization
(
Email_OrganizationID int NOT NULL AUTO_INCREMENT,
EmailID int,
OrganizationID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Email_OrganizationNotes varchar(255),
PRIMARY KEY (Email_OrganizationID),
FOREIGN KEY (EmailID) REFERENCES tbl_Email(EmailID),
FOREIGN KEY (OrganizationID) REFERENCES tbl_Organization(OrganizationID)
);

#Organization-to-Phone - junction table
create table jctbl_Organization_Phone
(
Organization_PhoneID int NOT NULL AUTO_INCREMENT,
PhoneID int,
OrganizationID int,
Organization_PhoneDisplayOrder int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Organization_PhoneNotes varchar(255),
PRIMARY KEY (Organization_PhoneID),
FOREIGN KEY (PhoneID) REFERENCES tbl_Phone(PhoneID),
FOREIGN KEY (OrganizationID) REFERENCES tbl_Organization(OrganizationID)
);

#Address-to-Organization - junction table
create table jctbl_Address_Organization
(
Address_OrganizationID int NOT NULL AUTO_INCREMENT,
OrganizationID int,
AddressID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Address_PersonNotes varchar(255),
PRIMARY KEY (Address_OrganizationID),
FOREIGN KEY (OrganizationID) REFERENCES tbl_Organization(OrganizationID),
FOREIGN KEY (AddressID) REFERENCES tbl_Address(AddressID)
);

#Address-to-Organization - junction table
create table jctbl_Organization_Person
(
Organization_PersonID int NOT NULL AUTO_INCREMENT,
OrganizationID int,
PersonID int,
TitleSuffixID int,
RoleID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
Organization_PersonNotes varchar(255),
PRIMARY KEY (Organization_PersonID),
FOREIGN KEY (OrganizationID) REFERENCES tbl_Organization(OrganizationID),
FOREIGN KEY (PersonID) REFERENCES tbl_Person(PersonID),
FOREIGN KEY (TitleSuffixID) REFERENCES lkutbl_TitleSuffix(TitleSuffixID),
FOREIGN KEY (RoleID) REFERENCES lkutbl_Role(RoleID)
);
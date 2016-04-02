create database SmallBusinessSolution;

#Person table
create table tblPerson
(
PersonID int NOT NULL AUTO_INCREMENT,
PersonCode varchar(255),
PersonCategoryID int,
NameLast varchar(255),
NameMiddle varchar(255),
NameFirst varchar(255),
PersonAddress1 varchar(255),
PersonAddress2 varchar(255),
PersonCity varchar(255),
PersonState varchar(255),
PersonPostCode varchar(255),
CountryID int,
PersonBirthDate date,
PersonDateOfFirstContact varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonNotes varchar(255),
PRIMARY KEY (PersonID),
FOREIGN KEY (PersonCategoryID) REFERENCES tblPersonCategories(PersonCategoryID),
FOREIGN KEY (CountryID) REFERENCES tblCountryRef(CountryID)
);

#Mail for person
create table tblMailForPerson
(
PersonEmailID int NOT NULL AUTO_INCREMENT,
PersonID int,
EmailTypeID int,
PersonCode varchar(255),
NameLast varchar(255),
NameMiddle varchar(255),
NameFirst varchar(255),
PersonAddress1 varchar(255),
PersonAddress2 varchar(255),
PersonCity varchar(255),
PersonState varchar(255),
PersonPostCode varchar(255),
CountryID int,
PersonBirthDate date,
PersonDateOfFirstContact varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonNotes varchar(255),
PRIMARY KEY (PersonID),
FOREIGN KEY (PersonCategoryID) REFERENCES tblPersonCategories(PersonCategoryID),
FOREIGN KEY (CountryID) REFERENCES tblCountryRef(CountryID)
);

#Phone for person
create table tblPhoneForPerson
(
PersonPhoneID int NOT NULL AUTO_INCREMENT,
PersonID int,
PersonPhoneType varchar(255),
PersonPhoneDisplayOrder int,
PersonPhoneCountryCode varchar(255),
PersonPhoneAreaCode varchar(255),
PersonPhonePrefix varchar(255),
PersonPhoneNumber varchar(255),
PersonPhoneExtension varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonPhoneNotes varchar(255),
PRIMARY KEY (PersonPhoneID),
FOREIGN KEY (PersonID) REFERENCES tblPerson(PersonID)
);

#Organization table
create table tblOrganization
(
OrganizationID int NOT NULL AUTO_INCREMENT,
OrganizationAddress1 varchar(255),
OrganizationAddress2 varchar(255),
OrganizationCity varchar(255),
OrganizationState varchar(255),
OrganizationPostalCode varchar(255),
CountryID int,
OrganizationTypeID int,
OrganizationDateOfFirstContact varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrganizationNotes varchar(255),
PRIMARY KEY (OrganizationID),
FOREIGN KEY (CountryID) REFERENCES tblCountryRef(CountryID),
FOREIGN KEY (OrganizationTypeID) REFERENCES tblOrganizationType(OrganizationTypeID)
);

#Email for organization
create table tblEmailForOrg
(
OrgEmailID int NOT NULL AUTO_INCREMENT,
OrganizationID int,
EmailTypeID int,
OrgEmail varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrgEmailNotes varchar(255),
PRIMARY KEY (OrgEmailID),
FOREIGN KEY (OrganizationID) REFERENCES tblOrganization(OrganizationID),
FOREIGN KEY (EmailTypeID) REFERENCES tblEmailType(EmailTypeID)
);

#Phone for organization
create table tblPhoneForOrg
(
OrgPhoneID int NOT NULL AUTO_INCREMENT,
OrganizationID int,
OrgPhoneType varchar(255),
OrgPhoneDisplayOrder int,
OrgPhoneCountryCode varchar(255),
OrgPhoneAreaCode varchar(255),
OrgPhonePrefix varchar(255),
OrgPhoneTelephoneNumber varchar(255),
OrgPhoneExtension varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrgPhoneNotes varchar(255),
PRIMARY KEY (OrgPhoneID),
FOREIGN KEY (OrganizationID) REFERENCES tblOrganization(OrganizationID)
);

#Categories for person - lookup table
create table tblPersonCategory
(
PersonCategoryID int NOT NULL AUTO_INCREMENT,
PersonCategoryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
PersonCategoryNotes varchar(255),
PRIMARY KEY (PersonCategoryID)
);

#Categories for organizations - lookup table
create table tblOrganizationCategory
(
OrganizationCategoryID int NOT NULL AUTO_INCREMENT,
OrganizationCategory varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrganizationCategoryNotes varchar(255),
PRIMARY KEY (OrganizationCategoryID)
);

#Organization type - lookup table
create table tblOrganizationType
(
OrganizationTypeID int NOT NULL AUTO_INCREMENT,
OrganizationCategoryID int,
OrganizationType varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrgPhoneNotes varchar(255),
PRIMARY KEY (OrganizationTypeID),
FOREIGN KEY (OrganizationCategoryID) REFERENCES tblOrganizationCategory(OrganizationCategoryID)
);

#Organization type - lookup table
create table tblOrganizationPerson
(
OrganizationPersonID int NOT NULL AUTO_INCREMENT,
OrganizationID int,
PersonID int,
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
OrgPhoneNotes varchar(255),
PRIMARY KEY (OrganizationPersonID),
FOREIGN KEY (OrganizationID) REFERENCES tblOrganization(OrganizationID),
FOREIGN KEY (PersonID) REFERENCES tblPerson(PersonID)
);
#State Reference - lookup table
create table tblStateRef
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
create table tblCountryRef
(
CountryRefID int NOT NULL AUTO_INCREMENT,
CountryAbbreviation varchar(255),
CountryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
CountryRefNotes varchar(255),
PRIMARY KEY (CountryRefID)
);

#Email type - lookup table
create table tblEmailType
(
EmailTypeID int NOT NULL AUTO_INCREMENT,
EmailType varchar(255),
CountryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
EmailTypeNotes varchar(255),
PRIMARY KEY (EmailTypeID)
);

#Email type - lookup table
create table tblEmailType
(
EmailTypeID int NOT NULL AUTO_INCREMENT,
EmailType varchar(255),
CountryName varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
EmailTypeNotes varchar(255),
PRIMARY KEY (EmailTypeID)
);

#Month - lookup table
create table tblMonth
(
MonthID int NOT NULL AUTO_INCREMENT,
MonthNumber varchar(255),
MonthName varchar(255),
MonthAbbreviation varchar(255),
LastUpdatedBy varchar(255),
LastUpdatedDate datetime,
MonthNotes varchar(255),
PRIMARY KEY (MonthID)
);


############################################
## End of People and organizations section
############################################
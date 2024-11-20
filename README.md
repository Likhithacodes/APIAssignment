# Blood Bank Web API

This project is a RESTful API for managing blood bank data, built using ASP.NET Core. It supports CRUD operations, searching, sorting, and pagination for blood bank entries.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete blood bank entries.
- **Search and Filter**: Search by blood type, donor name, or status.
- **Pagination and Sorting**: Retrieve paginated and sorted results for large datasets.
- **Swagger Integration**: Test the API directly using Swagger UI.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (with ASP.NET and web development workload)
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet)
- [Postman](https://www.postman.com/) or a similar API testing tool (optional)

---

## Steps to Run the Application

### 1. Clone the Repository
Run the following command to clone the project:
git clone https://github.com/Likhithacodes/APIAssignment

** 2. In Visual Studio, select the Open a project or solution option.**
![image](https://github.com/user-attachments/assets/6c80d8a0-d7df-4813-81eb-eb3260e05286)


Navigate to the cloned project folder and select the .sln (solution) file.

**3. Run the API Server**
Once the project is open, click on the IIS Express or https Run button in Visual Studio.
![image](https://github.com/user-attachments/assets/2d617b6b-b28a-449b-8173-50c9c75c4043)
This will start the API server, and Swagger UI will open automatically in your default browser.
![image](https://github.com/user-attachments/assets/93afc0f8-e9fc-4fe2-ab16-60f8dc06a17f)

**4. Test the API**
Using Swagger
Swagger UI will provide an interactive interface to test all endpoints.
Example CRUD operations (Create, Read, Update, Delete) can be performed directly from Swagger.

## Using Postman
**You can also use Postman to test the endpoints. Below are some examples:**
URL: (https://localhost:7143/api/BloodBank)

## Get All Blood Bank Entries
**Method: GET api/BloodBank**
![image](https://github.com/user-attachments/assets/4c23e1f9-8d93-4e39-bb54-ff97d8483569)

## POST the Entry
**Method:POST api/BloodBank**
![image](https://github.com/user-attachments/assets/0214e05d-cdcc-4f3f-a1d7-45030c716684)

Validation check:
for Invalid Input:
![image](https://github.com/user-attachments/assets/685b9004-5f2d-4b9a-b852-1f96781f6c8b)

## Get Blood Bank Entries By Id
**Method:GET api/BloodBank/{id}**
![image](https://github.com/user-attachments/assets/1a6062bf-07ce-4982-8ab9-5d957ab19cf9)

when Entry with Such ID is Not present
![image](https://github.com/user-attachments/assets/4d28d3db-321c-4824-b063-0d20fdb3f68f)

## Update the Entries
**Method:PUT api/BloodBank/{id}**
![image](https://github.com/user-attachments/assets/6ce7b9a5-6a69-4abe-8549-39fcb10bb369)

Invalid Input
![image](https://github.com/user-attachments/assets/e35c233a-30f6-4d3d-88c2-6039080efce9)

## Delete The Entry
**Method:DELETE api/BloodBank/{id}**
![image](https://github.com/user-attachments/assets/60e0283e-7e5f-4a1b-abaa-fd693f7e8753)

If the Entry is not present
![image](https://github.com/user-attachments/assets/f7bf828d-f735-43dc-9cae-0cac3cb558ca)

## Pagination
**Method:GET api/BloodBank/page**
![image](https://github.com/user-attachments/assets/08422e7f-5692-497a-b40b-2f44eb01efc9)

##Search 
** Method:GET api/BloodBank/search
Search Takes BloodType as Parameter

![image](https://github.com/user-attachments/assets/1402da4a-462a-4ba6-83ff-6679702f16b3)
##Sort
**Method:GET
sort can be done using BloodType or else the CollectionDate either in ASC or DESC.
![image](https://github.com/user-attachments/assets/a61aec33-f520-4484-8c82-3e4d7202479c)

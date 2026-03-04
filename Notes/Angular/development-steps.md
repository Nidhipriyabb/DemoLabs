# Development Steps

Important notes while working in Angular:

- DateTime in C# is converted to String in Angular (ISO string).
- We do NOT convert to Date immediately.
- Keep transport layer clean.

Reason for naming the DTO models for Category and Product, the same as backend:
- Easier cognitive mapping
- Easier documentation
- Easier maintenance
- Less translation confusion

----

## Step 01: Create Project

1. Create new Angular Project.  
2. Build.  
3. Run.


## Step 02: Add BootStrap

1. Register BootStrap.
2. Build.
3. Run.


## Step 03: Configure the API Base URL
    
It solves:
- Environment-based URL management
- Runtime configuration
- Deployment flexibility
    
STEPS:
1. add the `src/app/core/config/app-config.interface.ts`
2. add the `src/app/core/config/app-config.token.ts`
3. register the interface & token in `src/app/core/app.config.ts` file.
4. Build.
5. Run.
  

## Step 04: Register HttpClient 

1. Register HttpClient into the DI Providers in src/app/app.config.ts
2. Build.
3. Run.


## Step 05: Define ProblemDetails and ValidationProblemDetails client models

1. Add `src/app/core/models/problem-details.model.ts`<br />
   It defines the RFC 7807 ProblemDetails response INTERFACE MODEL
2. Add `src/app/core/models/validation-problem-details.model.ts`<br />
   It defines ValidationProblemDetails INTERFACE MODEL returned by the API
4. Build.
5. Run.


## Step 06: Configure the Global HTTP Error Interceptor

The API:
- Returns RFC 7807 ProblemDetails
- Returns ValidationProblemDetails
- Uses 409 for concurrency
- Uses structured errors

So the frontend must:
- Detect these responses
- Parse them safely
- Centralize error handling
- Prepare for JWT (future)

STEPS:
1. Add `src/app/core/models/app-http-error.model.ts`<br />
   It defines the standard error response INTERFACE MOODEL returned by the API 
2. Add `src/app/core/interceptors/http-error.interceptor.ts`<br />
   Centralizes error handling, using RxJS CatchError interceptor.
   It uses the three models:
    - `app-http-error.model.ts`
    - `problem-details.model.ts`
    - `src/app/core/models/validation-problem-details.model.ts`
3. In `app.config.ts` file, register the Interceptor modifying the HttpClient registration.
4. Build.
5. Run.

Angular now mirrors the backend result pattern:

> Backend → ProblemDetails
> Frontend → AppHttpError

So, when the Backend API returns:

```
{
  "type": "...",
  "title": "...",
  "status": 400,
  "errors": {
    "Name": ["Category name is required."]
  }
}
```

The Angular Frontend should NOT expose raw backend structure everywhere.

Instead:

```
    Backend (Result + ProblemDetails)
        ↓
    Angular HttpClient
        ↓
    httpErrorInterceptor
        ↓
    AppHttpError
        ↓
    Components
```

That keeps components simple and testable.  

----

## Step 07: Define the ApiBaseService

It will:
- Append apiBaseUrl
- Centralize HTTP calls
- Keep services clean
- Does not hide status codes
- Be JWT-ready
- Be easily testable
- Not duplicate the logic defined by the backend 
- Works with Interceptor
- Works with loading strategy

It will not:
- Wrap responses
- Interpret Result pattern
- Transform DTOs
- Swallow errors
- Be Infrastructure only

STEPS:
1. Add the ApiBaseService <br />
   Add the `src/app/core/services/api-base.service.ts` file
2. Build.
3. Run.

----

## Step 08: Setup the Loading Service

Purpose:
- To provide an automatic loading indicator for every HTTP request
- No manual isLoading = true in components
- Centralized behavior
- Scalable for future features

STEPS:
1. Configure the LoadingService and LoadingInterceptor:
  a. Create a LoadingService <br />
     Add `src/app/core/services/loading.service.ts`
  b. Create a LoadingInterceptor <br />
     Add `src/app/core/interceptors/loading.interceptor.ts`
  c. Register it in `src/app/app.config.ts`
     - Ensure that LoadingInterceptor is registered first.  So that loading starts immediately.
     - Next, register the httpErrorInterceptor, so as to ensure that loading stops even if error occurs.
2. Create and setup the GlobalSpinnerComponent which uses the LoadingService and LoadingInterceptor:
  a. Create the Angular Component - the GlobalSpinnerComponent<br />
     In the folder `src/app/shared/components/global-spinner/`: <br />
     Add the `global-spinner.component.ts` file
     Add the `global-spinner.component.html` file
     Add the `global-spinner.component.css` file
  b. Register the GlobalSpinnerComponent in the Root Component in the `src/app/app.ts` file <br />
     Also register `RouterLink`, `RouterLinkActive` components, used by the template.
  c. Wire it into the root layout in the `src/app/app.html` <br />
     ```
      <app-global-spinner></app-global-spinner>
      <router-outlet></router-outlet>
    ```
3. Build.
4. Run.

---

## Status Update!

We have now completed:

  - Core Layer
    - Config
    - ApiBaseService
    - LoadingService
    - Interceptors
  - Shared Layer
    - Global spinner
  - Application Shell
    - Bootstrap layout
    - Loader integration
    - Router integration

---

## Step 10: Run a Basic Test on the project

1. Prepare the test in the .spec.ts file for the component.  
   Eg: `app.spect.ts` file runs the test for the app component.
2. Build
   ```
   ng build
   ```
3. Run the test
   ```
   ng test
   ```

---

# Testing the Category API endpoints

## Step 01: Define folder structure for working with the Category API endpoints



1. Define the Contracts for the Category API in the `src/app/features/categories/models` folder

## Step 01: Define the folder structure for the Categories API

    ```
    features/
       categories/
           models/
           services/
           components/
               category-list/
               category-create/
               category-edit/
               category-delete/
    ```

## Step 02: Add the DTO models for the Category API feature

We add the models before setting up the service client.  Reason:
- Models define the contract.
- Services depend on models.
- Components depend on services.
- Tests depend on models.

STEPS:
1. add `src/app/features/categories/models/category-read.model.ts` file
2. add `src/app/features/categories/models/category-create.model.ts` file
3. add `src/app/features/categories/models/category-update.model.ts` file
4. add `src/app/features/categories/models/category-delete.model.ts` file
5. build
6. run

----

## Step 03: Setup the Category Service

Ensure, that it should:

- use HttpClient
- use centralized API base URL (your AppConfig token)
- handle ProblemDetails
- handle validation errors
- be ready for JWT later
- be clean and testable
- support concurrency (RowVersion)
- use strict typing

Remember:
> Services should NOT contain UI logic.

We will:

    ✔ NOT return raw HttpResponse
    ✔ NOT swallow errors
    ✔ NOT duplicate error logic
    ✔ Return strongly typed Observables
    ✔ Let global error interceptor handle ProblemDetails
    ✔ Keep service clean

STEPS:
1. Add `features/categories/services/category.service.ts` file


----

## Step 04: Add the Category-List Component

This component will:

- Call CategoryService.getAll()
- Show global loading spinner (already wired)
- Display the list of Categories in a table (using Bootstrap 5 classes)
- Handle normalized errors (through AppHttpError)
- Be clean and testable
- Prepare for Edit/Delete navigation

### STEPS to generate the files for the component:

#### OPTION A - Using Angular CLI (recommended):

Ensure that you are in the project root folder.

```
    > ng generate component features/categories/components/category-list --standalone
```

This is will the following files:
- `src/app/features/categories/components/category-list/category-list.spec.ts`
- `src/app/features/categories/components/category-list/category-list.ts`
- `src/app/features/categories/components/category-list/category-list.css` 
- `src/app/features/categories/components/category-list/category-list.html` 

##### OPTION B - Using Visual Studio 2026

1. Add the folder `/features/categories/components` if it does not exist
2. Now, add the component folder: `/features/categories/components/category-list` file
3. Finally, manually create each of the four files needed for the category-list component:
    - `src/app/features/categories/components/category-list/category-list.spec.ts`
    - `src/app/features/categories/components/category-list/category-list.ts`
    - `src/app/features/categories/components/category-list/category-list.css` 
    - `src/app/features/categories/components/category-list/category-list.html` 

### Next, check if the generated component builds and tests properly

    > `ng build`
    > `ng test`

We can now, proceed to write the code for the component!

---

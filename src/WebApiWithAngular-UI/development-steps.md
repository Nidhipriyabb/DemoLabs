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
3. Build.
4. Run.


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
1. Add `src/app/core/interceptors/http-error.interceptor.ts`<br />
    Centralizes error handling, using RxJS CatchError interceptor.
2. In `app.config.ts` file, register the Interceptor modifying the HttpClient registration.
3. Build.
4. Run.

----

## Step 07: Define the DTO Models for Categories

Add the DTO models for the Category API feature
1. add `src/app/features/categories/models/category-read.model.ts` file
2. add `src/app/features/categories/models/category-create.model.ts` file
3. add `src/app/features/categories/models/category-update.model.ts` file
4. add `src/app/features/categories/models/category-delete.model.ts` file
   
----

## Step 08: Define the ApiBaseService

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

## Step 09: Setup the Loading Service

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


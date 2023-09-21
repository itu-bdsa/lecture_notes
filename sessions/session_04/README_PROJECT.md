# Your turn now! — Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)
  - [3)  Project Review 1](#3-project-review-1)
  - [4) Prepare for next session](#4-prepare-for-next-session)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.



## 1) Software Development

### 1.a) Refactor the CSV Database to a Web Service

Implement two endpoints in your CSV database web service: `/cheep` and `/cheeps`.
Sending a JSON object, e.g., of the form `{"Author":"ropf","Message":"Hello, World!", "Timestamp": 1684229348}` as the body of an HTTP POST request to the `/cheep` endpoint shall store the cheep in the remote database.
An HTTP GET request to the `/cheeps` endpoint shall return all cheeps that are stored in the CSV database as a list of JSON objects.

This is a refactoring step.
That is, reuse suitable code from your current SimpleDB library project and move its functionality behind the web interface described above.


### 1.b) Refactor your _Chirp!_ CLI client to use the CSV Database Web Service

Refactor your client application so that it uses the web service CSV database to store and read cheeps.
That is, your _Chirp!_ CLI client shall now send HTTP `GET` and `POST` requests to the `/cheeps` and `/cheep` endpoint respectively.
It shall not call the methods from your `SimpleDB` library project directly anymore.

Do this refactoring in small steps:

#### Make both the CSV Database Web Service and the _Chirp!_ CLI client work on `localhost`

Make sure that the CSV database web service and the refactored _Chirp!_ CLI client work together as intended when both are executed on `localhost`.

#### Adapt your test suite

Adapt your unit, integration and end-to-end tests from last week's exercise so that they test the _Chirp!_ application with its new architecture.

Suitable integration tests for the CSV Database Web Service are likely:

a) When you send an HTTP `GET` request to the `/cheeps` endpoint the status code of the HTTP response is `200` and the response body contains a list of `Cheep` objects serialized to JSON.
b) When you send an HTTP `POST` request to the `/cheep` endpoint with a request body containing a JSON serialized `Cheep` object, you receive `200` as status code of the HTTP response.

Depending on your test cases of the CLI client, they will likely change only slightly compared to last week.
But likely all `Read` and `Store` method calls of your `SimpleDB` library are replaced by respective HTTP calls.

#### Deploy your CSV Database Web Service manually to Azure

Once you are sure that your CSV Database Web Service and _Chirp!_ CLI client can operate as intended on your local computer, manually deploy the CSV Database Web Service to Azure App Services. Do that as in class via:

```bash
az login
az webapp up --sku F1 --name bdsagroup<no>chirpremotedb --os-type Linux --location westeurope --runtime DOTNETCORE:7.0
```

**OBS**: replace `<no>` in the `--name` option above with the number of your group **before** executing the command.

Manually test if your client works together with the remote database when configured with the respective URL.
That is, your client application has to send requests to the newly deployed web service (under URL `https://bdsagroup<no>chirpremotedb.azurewebsites.net/`), not to a web service running on `localhost`.
Note, that you can retrieve the correct URL from the output of above command.

Additionally, from now on cheeps are no longer stored in a local CSV file on your computer but on the remote service hosted on Azure App Services.

|:warning:|  **Do not** interfere with the CSV Database Web Services from other groups! That is, do not send cheeps to be stored in another group's database!|
|---------|------------------------------------|

Once you verified that your client can interact with the CSV Database Web Service, shutdown that service with the following commands. The reason is, that you are configuring automatic deployment in the next task.

```bash
az webapp delete
az logout
```

## 2) Process

### 2.a) Add Automatic Deployment of your CSV Database Web Service

Add automatic deployments of your refactored CSV database to Azure App Services as a GitHub Action.
Likely the easiest way to configure a respective GitHub Actions workflow, is by registering the web service once on Azure App Services in the following way:
An illustrated guide of the following steps is accessible [here](https://app.tango.us/app/workflow/Creating-a-Remote-Azure-Database-for--NET-7--STS--on-Linux-with-Deployment-Center-cd9c4e3977184b7fb2a7e2d239e4d54f):

* Log onto <https://portal.azure.com/#home>
* Click the following sequence: top tab `App Services` → `+ Create` → choose `Web App`
* Set `Name` to `bdsagroup<no>chirpremotedb`, where `<no>` has to be replaced with the number of your group.
* Set `Region` to `North Europe`
* Set `Runtime stack` to `.NET 7 (STS)`
* Choose `Operating system` `Linux`
* Choose `Pricing Plan` `Free F1 (Shared infrastructure)`
* In the bottom, click the button `Review + create`
* After checking that all configuration is as expected, click the button `Create` in the bottom

* After reading a message saying _"`Your deployment is complete`"_, click `Go to resource`
* On the left choose `Deployment Center`
* Under `Source`, select `GitHub`
* Click `Authorize`
* Now choose organization (for you, it is your GitHub organization, i.e., `ITU-BDSA23-GROUP<no>`), your repository (`Chirp`) and the `main` branch
* Finish by clicking the `Save` button on the top

The last steps automatically create and store a GitHub Actions workflow in your repository and it automatically configures the required environment variables and secrets on GitHub.

In case your project is organized into `src` and `test` directories, you have to point the build and publish commands to the right projects in the repository:
  - Change lines 25 - 29 to:
  ```yaml
      - name: Build with dotnet
        run: dotnet build src/<Your.Chirp.CSVDB.Service>/ --configuration Release

      - name: dotnet publish
        run: dotnet publish src/<Your.Chirp.CSVDB.Service>/ -c Release -o ${{env.DOTNET_ROOT}}/myapp
  ```

After successful execution of the workflow, the app is available under: `https://bdsagroup<no>chirpremotedb.azurewebsites.net/`

### 2.b) Continue Automatic Releases of your _Chirp!_ CLI Clients

Continue to automatically release new versions of the CLI client. That is, now release at least one new version of the _Chirp!_ CLI client that is able to interact with your CSV Database Web Service.

Note, while all project groups are discouraged to interact with other group's CSV Database Web Services, be prepared for that the teachers or TAs send a small amount of `Cheeps` and want to read a small amount of these too.

## 3) Project Review 1

Prepare for the first project review (next Tuesday 26. Sept).
Be prepared to demonstrate and inspect with the assigned TA:
* How you build, test, and deploy your projects
* The current state of your project, i.e., local CLI based clients that talk to a web service database or that interact with a local `SimpleDB` CSV database.

In case you cannot meet with the TA who is assigned to your group, let her know well in advance that you cannot and reschedule to meeting to another suitable time slot!

## 4) Prepare for next session

Next session, we need that you have the `sqlite3` CLI program installed.
Do that on the terminal as described in the following:

- On WSL and Linux: `sudo apt install sqlite3`
- On MacOS `brew install sqlite3`

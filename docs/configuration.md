## Configuration

> The full configuration is at [appsettings.json](./src/Evlog.Web/appsettings.json). The application can be configured by setting environment variables. Use `__` to access child properties. So a config like:
> 
> ```js
> {
>  "AppSettings":
>  {
>    "DatabaseProvider": "MySql"
>  }
>}
>```
>
> can be set using `AppSettings__DatabaseProvider=MySql".

### Database configuration

| Configuration                   | Accepted Values / example | Description                    |
|---------------------------------|---------------------------|--------------------------------|
| `AppSettings__DatabaseProvider` | `MySql`                   | Select the database provider.  |
| `MySql__ConnectionString`       | `Server=localhost;Port=3307;Database=evlog;User=root;Password=Pa5sw0rd;` | The MySql connectionstring. |

### Email configuration

| Configuration            | Accepted Values / example | Description                                    |
|--------------------------|---------------------------|------------------------------------------------|
| `Email__FromName`        | `MySql`                   | The from name to use while sending the email.  |
| `Email__FromEmail`       | `noreply@yourdomain.com`  | The email address to the email from.           |
| `Email__Provider`        | `Log`, `SMTP`             | The email provider to use.                     |

#### Log Provider

This is a provider for testing. It logs the email contents the configured log output (defaults to the console).

#### SMTP provider

Use this to send emails using the Simple Mail Transfer Protocol (SMTP). The following example configures your application to send emails from a Gmail account:

| Configuration     | Gmail example             |
|-------------------|---------------------------|
| `SMTP__Host`      | `smtp.gmail.com`          |
| `SMTP__Port`      | `465`                     |
| `SMTP__Username`  | `example@gmail.com`       |
| `SMTP__Password`  | `accountpassword`         |
| `SMTP__Tls`       | `true`                    |


### Logging


| Configuration                    | Accepted Values / example                                      | Description                    |
|----------------------------------|----------------------------------------------------------------|--------------------------------|
| `Serilog__MinimumLevel__Default` | `Verbose`, `Debug`, `Information`, `Warning`, `Error`, `Fatal` | Configures log verbosity.      |


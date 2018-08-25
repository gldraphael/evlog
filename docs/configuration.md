## Configuration

The following JSON structure defines the configuration for the application:

```js
{
  "AppSettings": {
    "UseMongo": true // cannot be false as of now
  },
  "Mongo": {
    "Host": "localhost",
    "Port": 27017,
    "UseAuthentication": false,
    "ConnectTimeout": 2000,
    "Database": "evlog"
  }
}
```

TODO: elaborate more on this.

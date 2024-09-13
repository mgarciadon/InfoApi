# Weather Forecast Project

## Overview

This project consists of two .NET applications:

1. **InfoApi**: A backend API that provides weather forecast data.
2. **ClientApi**: A client application that consumes the weather forecast API and caches the data.

## InfoApi

**InfoApi** is a simple API that generates random weather forecasts. It provides an endpoint to retrieve a list of weather forecasts.

### Features

- **Weather Forecast Endpoint**: Provides a list of weather forecasts with date, temperature in Celsius and Fahrenheit, and a summary.

### Configuration

- The endpoint simulates a delay of 10 seconds to mimic a slow API response.

- Configuration settings can be adjusted in `appsettings.Development.json` and `launchSettings.json` for port changes.

## ClientApi

**ClientApi** is a client application that retrieves weather forecast data from **InfoApi** and caches the results.

### Features

- **Weather Forecast Caching**: Uses in-memory caching to store weather forecasts for a specified duration.

### Configuration

- Cache settings are configured directly in the application code to avoid using `appsettings.json`.

### Cache Configuration

- Cache configurations are specified directly in the application's configuration code. You can define multiple caches with different expiration times.

### Running the Project

1. **Start InfoApi**: Ensure **InfoApi** is running on its configured port.

2. **Start ClientApi**: Ensure **ClientApi** is running on its configured port.

3. **Access Swagger UI**: Navigate to the Swagger UI endpoint of **ClientApi** to test the API endpoints.

## How to Contribute

Feel free to fork the repository and submit pull requests. Please ensure that your code adheres to the coding standards and includes appropriate unit tests.

## License

This project is licensed - see the [LICENSE](LICENSE) file for details.

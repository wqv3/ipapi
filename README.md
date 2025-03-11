# ipapi

## overview

`ipapi` is a command-line tool that allows users to query information about an ip address, domain, or url using the ip-api service (https://ip-api.com). the program retrieves data such as geographical location, isp, region, timezone, and other details related to the given target. the results are displayed in the terminal and can be saved to a local `.json` file.

## features

- retrieve detailed information about ip addresses, domains, or urls.
- geolocation data, including continent, country, region, and city.
- timezone and currency information.
- isp and organization details.
- support for both ipv4 and domain name queries.
- saving query results to a `.json` file (dir: outp/*.json).
  
## requirements

- .net core sdk or .net 5/6 runtime installed.
- an active internet connection to access the ip-api service.

## example output

url/domain/ip: example.com status: success message: ok continent: north america continentcode: na country: united states countrycode: us region: california regionname: california city: los angeles district: - zip: 90001 latitude: 34.0522 longitude: -118.2437 timezone: america/los_angeles offset: -8 currency: usd isp: google llc organization: google llc as: as15169


5. **waiting for input**: after the information is displayed, you can press any key to exit the program.

## ip-api service

this program uses the **[ip-api](https://ip-api.com)** service to query data about ip addresses and domains. ip-api provides a reliable and fast api to fetch geolocation data and other associated information for a given ip address or domain.

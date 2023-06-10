# Overview

Tour De UI is the front end for the community organized bike race application.

## Getting Started

You should add a `.env` file with configuration specific to your event. Then run `npm start` to begin the frontend.

### Configuration

- `REACT_APP_AUTH0_DOMAIN` - domain from your Auth0 tenant
- `REACT_APP_AUTH0_CLIENTID` - client ID from your Auth0 tenant
- `REACT_APP_RACE_START` - race start time in the format `yyyy-MM-ddThh:mm`
- `REACT_APP_RACE_END` - race end time in the format `yyyy-MM-ddThh:mm`
- `REACT_APP_TIMEZONE` - timezone (ex: 'America/Chicago')
- `REACT_APP_SITE_TITLE` - title to appear on the browser tab
- `REACT_APP_API_BASE_URI` - base URI where the API lives, e.g: "https://tourde.org/api/"

# TvMaze scraper + api
## Thoughts
First thought, function app.
But that seems not handy, because of 10 minute limit. 
Durable functions would be ok, but too much overkill

- console app after all

## To Do / shortcuts taken
- Deleted items will not be synced to the scraped repository, only upserts
- Did not bother with a real separate model layer due to time constraints, but just an 'almost' copy. Only difference is that id must be a string for cosmos. Used Automapper for easy mapping. If I would be using real Model classes I would just write my own mapper class, instead of using AutoMapper.
- I could not get the rate limit to trigger / reproduce, even with parallel requests, so I did not give it much attention.
- The scraper runs indefinately and not with a CRON. It just loops.
## Example Appsettings
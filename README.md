# FizzBuzzAPI

This is a quick API designed to solve FizzBuzz just to showcase how I tend to build APIs when left to my own devices. This represents a few hours of work and is definitely expandable if I decide to do so.

It utilizes Serilog for logging and records to the console as well as daily logs to a file. It can be easily expanded on in the future to send them somewhere more useful but that is outside of the scope of what I am trying to do here. Logs cover exceptions, input, and output.

It is designed to take in a request to modularize FizzBuzz if needed and this is in lieu of QUERY not being a thing yet I fell back on utilizing a POST request to handle input of a JSON body. If none is provided it will solve FizzBuzz under normal conditions.

Tests are provided utilizing xUnit to handle testing. I didn't go too hog wild on the tests as this is at its core a very simple API but there should be enough to ensure proper working order.

Comments were provided where I felt context was needed. There is not comments for every function as I felt that could get excessive but I placed them where appropriate to give context.

This is a v1 API and as such our contracts are stored in a separate project to ensure we are always designing against the same inputs. Tests are likewise in a separate project although that is more just to avoid cluttering up the main project so the file structure is more readable.

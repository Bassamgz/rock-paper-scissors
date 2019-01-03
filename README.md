# rock-paper-scissors
	REST microservice for the game. 

## System Design
	- SOLID.
	- Containerized.
## Language/Frameworks
	- .NET Core 2.2
	- Docker.
	- VS Code/ VS 2017.
	- Resharper.
	- Stylecop.
	- xunit.
	- Moq.
	- AWS ECS.
	- Dockerhub.
	- Bitbucket.
	- Bitbucket Pipeline.
	- Trello integrated with Bitbucket.
	
### Descritpion
	Backend is very simple and there is 100% pipeline "bitbucket pipeline" in place which run tests, publish the docker image to dockerhub and deploy it on
	aws ecs using fargate mode.
	
#### Available APIs
	Just used given APIs in the document as below
	
	- POST /api/games/gameName
		Create a new game. Game name is unique for the simplicity.
		https://localhost:44348/api/games/TestGame

	- POST /api/games/gameName/join'playerName'
		Game allow supports only two players. So here two players can join. Player name isn't unique and player names aren't returned anywhere so players will count on their order of joining to know who won. 'Task to fix on trello backlog'.
		https://localhost:44348/api/games/TestGame/Player1

	- POST /api/games/gameName/playerName/move:int
		Playing your move is easy. Move is an enum with values as below, some validations in place.
		Move:
			Paper => 0
			Scissors => 1
			Rock=> 2

	- GET /api/games/{id}
		Getting the game status and below will be the given values.
		GameStatus:
			Created => 0
			PlayerOneMovePending => 1
			PlayerTwoMovePending => 2
			Tie => 3
			PlayerOneWon =>4
			PlayerTwoWon =>5

##### Testing
	- Not working due to a strange problem with my docker file
		- AWS ECS. 'Not working now, trying to solve a problem within my implementation'
			- Service is already deployed to ECS and just import the postman ecs saved project and enjoy.
		
		- Using Play with Docker: 'Depends on availability'
			- Login to PWD.
			- Add an instance.
			- docker run -d bgdk/rock-paper-scissors:19 -p 5050:80 
			- Test using postman by importing docker saved project.
		- Local Docker:
			- Start docker then run below command.
			- docker run -d bgdk/rock-paper-scissors:17 -p 5050:80
			- Test using postman by importing docker saved project.

	- From inside VS	
		- Run in debug/release mode IIS
			- Then update link inside postman
		- Run in debug mode docker
			- Then update link inside postman	
	
	Postman collection
		https://www.getpostman.com/collections/c33f8d0b318d56d48d3f

##### My approach to solve the docker problem
	Due to this problem, the whole pipeline automation isn't working anymore. 
	- I am using VS Docker support.
	- First problem, with https and certificates so I just disabled https for simplicity.
	- 2nd and main problem is port isn't being mapped at all when running the container for the image.
		- Tried on both Windows/Linux mode.
		- Tried to build the machine from Play With Docker.
		- Disabled exposed at all.
		- Investigated container in interactive mode and using inspect to see logs.
		- Curl from inside container to host works ,but not otherwise.
	- Created a new empty web api, didn't work either.
	- It works for docker using vs debug mode only.


	
	

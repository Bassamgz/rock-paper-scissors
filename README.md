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
	Backend is very simple and there is 100% pipeline "bitbucket pipeline" in place which run tests, publishes the docker image and deploy it on
	aws ecs using fargate mode.
	
#### Available APIs
	Just used given APIs in the document as below
	
	- POST /api/games/gameName
		Create a new game. Game name is unique for the simplicity.
		https://localhost:44348/api/games/TestGame
	- POST /api/games/gameName/join'playerName'
		Game allow supports only two players. So here two players can join. Player name isn't unique and player names aren't returned anywhere
		so players will count on their order of joining to know who won. 'Task to fix on trello backlog'.
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
	- AWS ECS.
	Service is already deployed to ECS and just import the postman ecs saved project and enjoy.
	
	- Using Play with Docker:
		- No need to install docker. Just use PWD and run a container there.
		- Login to PWD.
		- Add an instance.
		- docker run -d bgdk/rock-paper-scissors:14 -p 443:8443 
		- Test using postman by importing docker saved project.
	
	- Local Docker:
		- Start docker then run below command.
		- docker run -d bgdk/rock-paper-scissors:14 -p 443:8443
		- Test using postman by importing docker saved project.
	
	- Visual Studio
		- Just run the 'RockPaperScissors.API.GameService' in whatever mode and import postman vs saved project
	
	Postman collection
		https://www.getpostman.com/collections/c33f8d0b318d56d48d3f
	
	

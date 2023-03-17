.PHONY: build run

build:
	docker-compose up --build --remove-orphans

run:
	@[ "${CONTAINER}" ] && \
		(docker exec -it $$CONTAINER /bin/bash -c 'cd /usr/src/app/dotnet-sdk-test/ && dotnet run Program.cs') || \
		(cd /usr/src/app/dotnet-sdk-test/ && dotnet run Program.cs)
.PHONY: build run

build:
	docker-compose up --build --remove-orphans

run:
	@[ "${CONTAINER}" ] && \
		(docker exec -it $$CONTAINER /bin/bash -c 'cd /usr/src/app/dotnet-sdk-test/ && dotnet run Program.cs') || \
		(cd /usr/src/app/dotnet-sdk-test/ && dotnet run Program.cs)

start:
	docker-compose up --build --remove-orphans --detach
	# Wait for the container to be running before attaching
	@while [ -z "$$(docker-compose ps -q dotnetSDK)" ]; do \
		sleep 1; \
	done
	docker attach $$(docker-compose ps -q dotnetSDK)
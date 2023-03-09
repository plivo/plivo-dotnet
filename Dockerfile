FROM ubuntu:latest

WORKDIR /usr/src/app

RUN apt-get update && apt-get install -y wget git vim make
RUN apt-get install -y apt-transport-https

# Install dotnet sdk and runtime: https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
RUN chmod +x ./dotnet-install.sh
RUN ./dotnet-install.sh --version latest
RUN rm ./dotnet-install.sh

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT 1
ENV DOTNET_ROOT /root/.dotnet
ENV PATH $PATH:/root/.dotnet:/root/.dotnet/tools
RUN dotnet --info

# Copy setup script
COPY setup_sdk.sh /usr/src/app/
RUN chmod a+x /usr/src/app/setup_sdk.sh

ENTRYPOINT [ "/usr/src/app/setup_sdk.sh" ]
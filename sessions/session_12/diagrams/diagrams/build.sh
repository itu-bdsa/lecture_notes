#!/usr/bin/env bash

# wget https://github.com/plantuml/plantuml/releases/download/v1.2024.7/plantuml-1.2024.7.jar
java -jar plantuml-1.2024.7.jar *.uml
mv *.png ../images
mv ../images/domain_model_with_identity.png ../images_private/

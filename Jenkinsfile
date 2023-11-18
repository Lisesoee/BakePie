pipeline{
    agent any
    triggers{
        pollSCM("* * * * *")
    }
    stages{
        stage("Build"){
            steps{
                sh "docker compose build"
            }
            post{
                always{
                    echo "========Done executing build========"
                }
                success{
                    echo "========Build successfully========"
                }
                failure{
                    echo "======== Build failed========"
                }
            }
        }
        stage("Prepare test"){
            steps{
                echo "pretend: docker compose up indexer"
            }
        }
        stage("Test"){
            steps{
                echo "pretend: docker compose up test"
            }
        }
        stage("Deliver"){
            steps{
                echo "Pretend like we are pushing the docker compose file to DockerHub with appropriate dockerhub credentials"
            }
        }
    }
    post{
        always{
            echo "========Pipeline done========"
        }
        success{
            echo "========Pipeline executed successfully========"
        }
        failure{
            echo "========Pipeline execution failed========"
        }
    }
}
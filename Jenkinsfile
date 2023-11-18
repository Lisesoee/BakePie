pipeline{
    agent{
        label any
    }
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
    }
    post{
        always{
            echo "========Pipeline done========"
        }
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
        }
    }
}
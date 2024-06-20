pipeline {
    agent any
     
    environment {
        SONAR_TOKEN = credentials('scanner') 
        SONAR_URL = 'http://172.16.1.70:9000'
        PATH = "/usr/bin:$PATH"
        DOCKERHUB_TOKEN = credentials('dockerhub')
    }

    stages {
        stage('Checkout Frontend') {
            steps {
                dir('Clinique') {
                    git url: 'https://github.com/aymeennefzi/Clinique_devops.git', branch: 'master'
                }
            }
        }
        stage('Verify Checkout') {
            steps {
                script {
                    sh 'ls -la'
                }
            }
        }
        stage('Restore') {
            steps {
                script {
                    sh 'dotnet restore Clinic.csproj'
                }
            }
        }
        stage('Build') {
            steps {
                script {
                    sh 'dotnet build Clinic.csproj --configuration Release'
                }
            }
        }
        stage('Run Unit Tests') {
            steps {
                script {
                    def testResultsDir = "${WORKSPACE}/test-results"
                    sh "mkdir -p ${testResultsDir}" 
                    sh "dotnet test --logger trx --results-directory ${testResultsDir}" 
                }
                step([$class: 'MSTestPublisher', testResultsFile: "${WORKSPACE}/test-results/*.trx"])
            }
        }
        stage('SonarQube Analysis') {
            steps {
                withCredentials([string(credentialsId: 'scanner', variable: 'SONAR_TOKEN')]) {
                    script {
                        sh "docker run --rm -e SONAR_TOKEN=$SONAR_TOKEN -v ${WORKSPACE}:/usr/src -w /usr/src sonarsource/sonar-scanner-cli sonar-scanner -Dsonar.projectKey=Clinique_project -Dsonar.host.url=$SONAR_URL -Dsonar.login=$SONAR_TOKEN"
                    }
                }
            }
        }
        stage('Publish Artifacts') {
            steps {
                script {
                    sh 'dotnet publish --configuration Release --output ./publish'
                }
                archiveArtifacts artifacts: 'publish/**/*', allowEmptyArchive: true
            }
        }
        
    }
}

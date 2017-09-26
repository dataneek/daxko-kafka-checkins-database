# Part 1 - build the dacpac
docker build -t kafka-checkins-database-builder -f Dockerfile.builder .
rmdir -Force -Recurse out
mkdir out
docker run --rm -v $pwd\out:c:\bin -v $pwd\src:c:\src kafka-checkins-database-builder

# Part 2 - build the SQL server image
docker build -t neekgreen/kafka-checkins-database .
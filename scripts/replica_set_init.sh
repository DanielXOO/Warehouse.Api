#!/bin/bash

set -e
set -u
# set -x	# Uncomment for debugging


# The replica set configuration document
#
# warehouse-db-primary: Primary, since we initiate the replica set on monog0
# warehouse-db-secondary: Secondary
_config=\
'
{
	"_id": "rs0",
	"members": [
		{ "_id": 0, "host": "warehouse-db-primary" },
		{ "_id": 1, "host": "warehouse-db-secondary" }
	]
}
'

sleep 5;


if [[ -n "${DB_USERNAME:-}" && -n "${DB_PASSWORD:-}" ]]; then
	mongosh --quiet \
	--host warehouse-db-primary \
	-u $DB_USERNAME -p $DB_PASSWORD \
	--authenticationDatabase admin \
	<<-EOF
		rs.initiate($_config);
	EOF
else
	mongosh --quiet \
	--host warehouse-db-primary \
	<<-EOF
		rs.initiate($_config);
	EOF
fi

exec "$@"
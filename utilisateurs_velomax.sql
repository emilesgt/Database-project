DROP USER IF EXISTS bozo@localhost;
CREATE USER bozo@localhost IDENTIFIED BY 'bozo';
REVOKE ALL PRIVILEGES
ON *
FROM bozo@localhost;
GRANT SELECT ON *.* TO bozo@localhost;
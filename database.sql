CREATE TABLE IF NOT EXISTS `accounts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `products` (
    `id` int NOT NULL AUTO_INCREMENT,
    `name` varchar(255) NOT NULL,
    `description` varchar(255) NOT NULL,
    `price` decimal NOT NULL,
    `sku` varchar(255) NOT NULL,
    `qty` int NOT NULL,
    `created_at` datetime NOT NULL,
    `updated_at` datetime NOT NULL,
    PRIMARY KEY (`id`)
);


CREATE TABLE IF NOT EXISTS `basket` (
    `id` int NOT NULL AUTO_INCREMENT,
    `account_id` INT REFERENCES `accounts`(`id`),
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `basket_detail`(
    `id` int NOT NULL AUTO_INCREMENT,
    `product_id` INT NOT NULL REFERENCES `products`(`id`),
    `basket_id` INT NOT NULL REFERENCES `basket`(`id`),
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `payments`(
    `id` int NOT NULL AUTO_INCREMENT,
    `order_id` INT NOT NULL REFERENCES `orders`(`id`),
    `amount` int NOT NULL,
    `method` INT NOT NULL REFERENCES `payment_methods`(`id`),
    `created_at` datetime NOT NULL,
    `updated_at` datetime NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `payment_methods`(
    `id` int NOT NULL AUTO_INCREMENT,
    `name` varchar(255) NOT NULL,
    PRIMARY KEY (`id`)
);



CREATE TABLE IF NOT EXISTS `orders` (
    `id` int NOT NULL AUTO_INCREMENT,
    `status` varchar(255) NOT NULL,
    `account_id` INT NOT NULL REFERENCES `accounts`(`id`),
    `payment_id` INT NOT NULL REFERENCES `payments`(`id`),
    `created_at` datetime NOT NULL,
    `updated_at` datetime NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `order_detail`(
    `id` int NOT NULL AUTO_INCREMENT,
    `order_id` INT NOT NULL REFERENCES `orders`(`id`),
    `product_id` INT NOT NULL REFERENCES `products`(`id`),
    `qty` int NOT NULL,
    PRIMARY KEY (`id`)
);
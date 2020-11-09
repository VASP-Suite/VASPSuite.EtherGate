Feature: Generate signing key

  Scenario: Calling GenerateSigningKey method of a VASPKeysGenerator
    When I call GenerateSigningKey method of a VASPKeysGenerator
    Then the GenerateSigningKey call result should be a valid pair of signing key and private key
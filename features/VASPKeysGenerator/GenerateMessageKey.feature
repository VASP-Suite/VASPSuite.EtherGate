Feature: Generate message key

  Scenario: Calling GenerateMessageKey method of a VASPKeysGenerator
    When I call GenerateMessageKey method of a VASPKeysGenerator
    Then the GenerateMessageKey call result should be a valid pair of message key and private key
Feature: Generate transport key

  Scenario: Calling GenerateTransportKey method of a VASPKeysGenerator
    When I call GenerateTransportKey method of a VASPKeysGenerator
    Then the GenerateTransportKey call result should be a valid pair of transport key and private key
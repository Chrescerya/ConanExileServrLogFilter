using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LogProcessor : MonoBehaviour {

	public InputField _input;
	public GameObject _logOutputPrefab;
	public Transform _logContentPanel;
	private StreamReader _reader;
	private string _log = string.Empty;
	private List<GameObject> _childrenList = new List<GameObject> ();

	private int _emptyLines = 0;
	private int _nonTimeStampedLines = 0;
	private int _callStackErrorsFiltered = 0;
	private int _aiLogOthers = 0;

	private int _aiNoValidSpawn = 0;
	private int _aiRandomSpawnNotAvailable = 0;
	private int _aiNoDataForSpawner = 0;

	private int _initLog = 0;
	private int _memoryLog = 0;
	private int _dreamlandLog = 0;
	private int _translationWarning = 0;
	private int _assetRegistery = 0;
	private int _packageLocalizationCacheLog = 0;
	private int _moduleManagerLog = 0;
	private int _windowsMediaFoundationLog = 0;
	private int _windowsMoviePlayerLog = 0;
	private int _packageHandlerLog = 0;
	private int _objectArrayLog = 0;
	private int _objectAllocatorLog = 0;
	private int _streamingErrorLog = 0;
	private int _worldLog = 0;
	private int _audioLog = 0;
	private int _physicsLog = 0;
	private int _engineLog = 0;
	private int _loadLog = 0;
	private int _skeletatMeshLog = 0;
	private int _spawnTable = 0;
	private int _networkLog = 0;
	private int _persistenceLog = 0;
	private int _handshakeLog = 0;
	private int _nullObjects = 0;
	private int _heatmapInfo = 0;

	private int _fileNotFound = 0;
	private int _objectNotFound = 0;
	private int _failedToLoad = 0;
	private int _healthNotFound = 0;
	private int _skippedProperties = 0;

	private int _netAcceptedConnections = 0;
	private int _netLittleEndian = 0;
	private int _netPostAcceptedConnections = 0;
	private int _netGarbageCollected = 0;
	private int _netClientSpeed = 0;
	private int _netLoginRequest = 0;
	private int _netJoinRequest = 0;
	private int _netJoinSucceeded = 0;
	private int _netCleanUp = 0;
	private int _netCloseConnection = 0;
	private int _netLocalNetworkVersion = 0;
	private int _netAcceptingChannel = 0;
	private int _netOthers = 0;

	private int _combat = 0;

	private int _unprocessedLines = 0;
	private int _processedLines = 0;

	// Use this for initialization
	public void OnProcessClicked () {

		if (_input == null)
			return;

		if (_input.text == string.Empty)
			return;

		if (_childrenList.Count > 0)
		{
			for (int i = 0; i < _childrenList.Count; i++)
			{
				Destroy(_childrenList[i]);
			}
		}
		_childrenList.Clear ();

		_emptyLines = 0;
		_nonTimeStampedLines = 0;
		_callStackErrorsFiltered = 0;

		_aiLogOthers = 0;
		_aiNoValidSpawn = 0;
		_aiRandomSpawnNotAvailable = 0;
		_aiNoDataForSpawner = 0;

		_initLog = 0;
		_memoryLog = 0;
		_dreamlandLog = 0;
		_assetRegistery = 0;
		_packageLocalizationCacheLog = 0;
		_moduleManagerLog = 0;
		_windowsMediaFoundationLog = 0;
		_windowsMoviePlayerLog = 0;
		_packageHandlerLog = 0;
		_objectArrayLog = 0;
		_objectAllocatorLog = 0;
		_streamingErrorLog = 0;
		_worldLog = 0;
		_audioLog = 0;
		_physicsLog = 0;
		_engineLog = 0;
		_loadLog = 0;
		_skeletatMeshLog = 0;
		_spawnTable = 0;
		_networkLog = 0;
		_persistenceLog = 0;
		_handshakeLog = 0;
		_nullObjects = 0;
		_heatmapInfo = 0;

		_fileNotFound = 0;
		_objectNotFound = 0;
		_failedToLoad = 0;
		_healthNotFound = 0;
		_skippedProperties = 0;

		_netAcceptedConnections = 0;
		_netLittleEndian = 0;
		_netPostAcceptedConnections = 0;
		_netGarbageCollected = 0;
		_netClientSpeed = 0;
		_netLoginRequest = 0;
		_netJoinRequest = 0;
		_netJoinSucceeded = 0;
		_netCleanUp = 0;
		_netCloseConnection = 0;
		_netLocalNetworkVersion = 0;
		_netAcceptingChannel = 0;
		_netOthers = 0;

		_combat = 0;

		_translationWarning = 0;
		_unprocessedLines = 0;
		_processedLines = 0;

		string filepath = _input.text;
		_reader = new StreamReader (filepath);

		if (_reader == null)
			return;

		string line = _reader.ReadLine ();

		//open file in specific directory
		//if found start processing data
		while(line != null)
		{

			ProcessLine (line);
				
			line = _reader.ReadLine ();
		}


		CreateScrollviewEntry("_emptyLines = " + _emptyLines + "\n");
		CreateScrollviewEntry("_nonTimeStampedLines = " + _nonTimeStampedLines + "\n");
		CreateScrollviewEntry("_callStackErrorsFiltered = " + _callStackErrorsFiltered + "\n");

		CreateScrollviewEntry("_aiNoValidSpawn = " + _aiNoValidSpawn + "\n");
		CreateScrollviewEntry("_aiNoDataForSpawner = " + _aiNoDataForSpawner + "\n");
		CreateScrollviewEntry("_aiRandomSpawnNotAvailable = " + _aiRandomSpawnNotAvailable + "\n");
		CreateScrollviewEntry("_aiLogOthers = " + _aiLogOthers + "\n");

		CreateScrollviewEntry("_initLog = " + _initLog + "\n");
		CreateScrollviewEntry("_memoryLog = " + _memoryLog + "\n");
		CreateScrollviewEntry("_dreamlandLog = " + _dreamlandLog + "\n");
		CreateScrollviewEntry("_assetRegistery = " + _assetRegistery + "\n");
		CreateScrollviewEntry("_packageLocalizationCacheLog = " + _packageLocalizationCacheLog + "\n");
		CreateScrollviewEntry("_moduleManagerLog = " + _moduleManagerLog + "\n");
		CreateScrollviewEntry("_windowsMediaFoundationLog = " + _windowsMediaFoundationLog + "\n");
		CreateScrollviewEntry("_windowsMoviePlayerLog = " + _windowsMoviePlayerLog + "\n");
		CreateScrollviewEntry("_packageHandlerLog = " + _packageHandlerLog + "\n");
		CreateScrollviewEntry("_objectArrayLog = " + _objectArrayLog + "\n");
		CreateScrollviewEntry("_objectAllocatorLog = " + _objectAllocatorLog + "\n");
		CreateScrollviewEntry("_streamingErrorLog = " + _streamingErrorLog + "\n");
		CreateScrollviewEntry("_worldLog = " + _worldLog + "\n");
		CreateScrollviewEntry("_audioLog = " + _audioLog + "\n");
		CreateScrollviewEntry("_physicsLog = " + _physicsLog + "\n");
		CreateScrollviewEntry("_engineLog = " + _engineLog + "\n");
		CreateScrollviewEntry("_loadLog = " + _loadLog + "\n");
		CreateScrollviewEntry("_skeletatMeshLog = " + _skeletatMeshLog + "\n");
		CreateScrollviewEntry("_spawnTable = " + _spawnTable + "\n");
		CreateScrollviewEntry("_networkLog = " + _networkLog + "\n");
		CreateScrollviewEntry("_persistenceLog = " + _persistenceLog + "\n");
		CreateScrollviewEntry("_handshakeLog = " + _handshakeLog + "\n");
		CreateScrollviewEntry("_nullObjects = " + _nullObjects + "\n");
		CreateScrollviewEntry("_heatmapInfo = " + _heatmapInfo + "\n");

		CreateScrollviewEntry("_fileNotFound = " + _fileNotFound + "\n");
		CreateScrollviewEntry("_objectNotFound = " + _objectNotFound + "\n");
		CreateScrollviewEntry("_failedToLoad = " + _failedToLoad + "\n");
		CreateScrollviewEntry("_healthNotFound = " + _healthNotFound + "\n");
		CreateScrollviewEntry("_skippedProperties = " + _skippedProperties + "\n");

		CreateScrollviewEntry("_netAcceptedConnections = " + _netAcceptedConnections + "\n");
		CreateScrollviewEntry("_netLittleEndian = " + _netLittleEndian + "\n");
		CreateScrollviewEntry("_netPostAcceptedConnections = " + _netPostAcceptedConnections + "\n");
		CreateScrollviewEntry("_netGarbageCollected = " + _netGarbageCollected + "\n");
		CreateScrollviewEntry("_netClientSpeed = " + _netClientSpeed + "\n");
		CreateScrollviewEntry("_netLoginRequest = " + _netLoginRequest + "\n");
		CreateScrollviewEntry("_netJoinRequest = " + _netJoinRequest + "\n");
		CreateScrollviewEntry("_netJoinSucceeded = " + _netJoinSucceeded + "\n");
		CreateScrollviewEntry("_netCleanUp = " + _netCleanUp + "\n");
		CreateScrollviewEntry("_netCloseConnection = " + _netCloseConnection + "\n");
		CreateScrollviewEntry("_netLocalNetworkVersion = " + _netLocalNetworkVersion + "\n");
		CreateScrollviewEntry("_netAcceptingChannel = " + _netAcceptingChannel + "\n");
		CreateScrollviewEntry("_netOthers = " + _netOthers + "\n");


		CreateScrollviewEntry("_combat = " + _combat + "\n");
		CreateScrollviewEntry("_translationWarning = " + _translationWarning + "\n");
		CreateScrollviewEntry("other lines filtered = " + _processedLines + "\n");
		CreateScrollviewEntry("remaining lines = " + _unprocessedLines);

		Debug.Log (_log);
	}

	void ProcessLine (string line)
	{
		if (line == string.Empty) {
			_emptyLines += 1;
		}
		else if (!line.StartsWith ("[") && line.Trim ().StartsWith ("Function")) {
			CallStackFiltering (line);
		}
		else if (!line.StartsWith ("[")) {
			_nonTimeStampedLines += 1;
		}
		else if (line.Contains ("Script call stack:")) {
			CallStackFiltering (line);
		}
		else if (line.Contains ("LogTextLocalizationManager")) {
			_translationWarning += 1;
		}
		else if (line.Contains ("LogInit")) {
			_initLog += 1;
		}
		else if (line.Contains ("LogMemory")) {
			_memoryLog += 1;
		}
		else if (line.Contains ("Dreamworld")) {
			_dreamlandLog += 1;
		}
		else if (line.Contains ("LogAssetRegistry")) {
			_assetRegistery += 1;
		}
		else if (line.Contains ("LogPackageLocalizationCache")) {
			_packageLocalizationCacheLog += 1;
		}
		else if (line.Contains ("LogModuleManager")) {
			_moduleManagerLog += 1;
		}
		else if (line.Contains ("LogWmfMedia")) {
			_windowsMediaFoundationLog += 1;
		}
		else if (line.Contains ("LogWindowsMoviePlayer")) {
			_windowsMoviePlayerLog += 1;
		}
		else if (line.Contains ("LogAIModule")) {
			_aiLogOthers += 1;
		}
		else if (line.Contains ("PacketHandlerLog")) {
			_packageHandlerLog += 1;
		}
		else if (line.Contains ("LogUObjectArray")) {
			_objectArrayLog += 1;
		}
		else if (line.Contains ("LogUObjectAllocator")) {
			_objectAllocatorLog += 1;
		}
		else if (line.Contains ("LogLinker")) {
			ProcessLinkerLog (line);
		}
		else if (line.Contains ("LogUObjectGlobals")) {
			ProcessObjectGlobals (line);
		}
		else if (line.Contains ("LogStreaming:Error:")) {
			ProcessStreamingErrors (line);
		}
		else if (line.Contains ("LogWorld")) {
			_worldLog += 1;
		}
		else if (line.Contains ("Audio:Display:")) {
			_audioLog += 1;
		}
		else if (line.Contains ("LoadErrors")) {
			ProcessLoadErrors (line);
		}
		else if (line.Contains ("CreateHealthPool")) {
			ProcessHealthPoolWarning (line);
		}
		else if (line.Contains ("Skipping saved property")) {
			ProcessSkipedProperties (line);
		}
		else if (line.Contains ("LogPhysics")) {
			_physicsLog += 1;
		}
		else if (line.Contains ("LogEngine")) {
			_engineLog += 1;
		}
		else if (line.Contains ("LogNet")) {
			ProcessNetLog (line);
		}
		else if (line.Contains ("LogLoad")) {
			_loadLog += 1;
		}
		else if (line.Contains ("LogSkeletalMesh")) {
			_skeletatMeshLog += 1;
		}
		else if (line.Contains ("SpawnTable")) {
			_spawnTable += 1;
		}
		else if (line.Contains ("GlobalServerChannel")) {
			_processedLines += 1;
		}
		else if (line.Contains ("ConanSandbox")) {
			_processedLines += 1;
		}
		else if (line.Contains ("Persistence")) {
			_persistenceLog += 1;
		}
		else if (line.Contains ("Network")) {
			_networkLog += 1;
		}
		else if (line.Contains ("AI")) {
			ProcessAiLog (line);
		}
		else if (line.Contains ("Combat")) {
			_combat += 1;
			CreateLogEntry (line);
		}
		else if (line.Contains ("Login:Display")) {
			ProcessLoginDisplay (line);
		}
		else if (line.Contains ("LogHandshake")) {
			_handshakeLog += 1;
		}
		else if (line.Contains ("NULL object")) {
			_nullObjects += 1;
		}
		else if (line.Contains ("HeatmapMetrics:Display")) {
			_heatmapInfo += 1;
		}
		else if (line.Contains ("Crafting Multiplier set to")) {
			_processedLines += 1;
		}
		else if (line.Contains ("Emote_Worship")) {
			_processedLines += 1;
		}
		else if (line.Contains ("URecipeItem - Failed to load BuildingModule")) {
			_processedLines += 1;
		}
		else if (line.Contains ("SpawnActor failed because of collision at the spawn")) {
			_processedLines += 1;
		}
		else if (line.Contains ("LogExternalProfiler")) {
			_processedLines += 1;
		}
		else if (line.Contains ("out of bounds")) {
			_processedLines += 1;
		}
		else if (line.Contains ("History overflow")) {
			_processedLines += 1;
		}
		else if (line.Contains ("LogAnimMontage:Warning")) {
			_processedLines += 1;
		}
		else if (line.Contains ("Building:Warning")) {
			CreateLogEntry (line);
		}
		else if (line.Contains ("LogCharacterMovement")) {
			CreateLogEntry (line);
		}
		else if (line.Contains ("ItemInventory")) {
			CreateLogEntry (line);
		}
		else if (line.Contains ("BaseHumanoidNPC")) {
			CreateLogEntry (line);
		}
		else if (line.Contains ("LogOnline:Display: STEAM:")) {
			CreateLogEntry (line);
		}
		else if (line.Contains ("ChatWindow")) {
			CreateLogEntry (line);
		}

		else {
			_unprocessedLines += 1;
		}
	}

	private void CallStackFiltering(string line)
	{	
		if (line.Contains ("Script call stack:")) {
			_callStackErrorsFiltered += 1;
			line = _reader.ReadLine ();
			while (!line.StartsWith ("[") && line.Trim ().StartsWith ("Function")) {
				line = _reader.ReadLine ();
			}
			ProcessLine (line);
		}
	}
	private void ProcessAiLog(string line)
	{
		if (line.Contains ("Attempting to spawn wildlife") && line.Contains ("Did not find a valid spawn point."))
		{
			_aiNoValidSpawn += 1;
		}
		else if (line.Contains ("Random spawn point unavailable from static navigation"))
		{
			_aiRandomSpawnNotAvailable += 1;	
		}
		else if (line.Contains ("NoDataForSpawner"))
		{
			_aiNoDataForSpawner += 1;	
		}
		else
		{
			_aiLogOthers += 1;
		}
	}

	void ProcessLinkerLog (string line)
	{
		if (line.Contains ("Can't find file"))
		{
			_fileNotFound += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessObjectGlobals(string line)
	{
		if (line.Contains ("Can't find file"))
		{
			_fileNotFound += 1;
		}
		else if(line.Contains("Failed to find object"))
		{
			_objectNotFound += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessStreamingErrors (string line)
	{
		if (line.Contains ("Couldn't find file"))
		{
			_fileNotFound += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessLoadErrors (string line)
	{
		if (line.Contains ("Failed to load"))
		{
			_failedToLoad += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessHealthPoolWarning (string line)
	{
		if (line.Contains ("Could not find a health"))
		{
			_healthNotFound += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessSkipedProperties (string line)
	{
		if (line.Contains ("Skipping saved property"))
		{
			_skippedProperties += 1;
		}
		else
		{
			_processedLines += 1;
			Debug.LogWarning (line);
		}
	}
	void ProcessNetLog (string line)
	{
		if (line.Contains ("NotifyAcceptingConnection") || line.Contains("NotifyAcceptedConnection") || line.Contains("AddClientConnection"))
		{
			_netAcceptedConnections += 1;
		}
		else if (line.Contains ("little endian"))
		{
			_netLittleEndian += 1;
		}
		else if (line.Contains ("Server accepting post-challenge connection"))
		{
			_netPostAcceptedConnections += 1;
		}
		else if (line.Contains ("might have been GC'd"))
		{
			_netGarbageCollected += 1;
		}
		else if (line.Contains ("Client netspeed"))
		{
			_netClientSpeed += 1;
		}
		else if (line.Contains ("Login request"))
		{
			_netLoginRequest += 1;
		}
		else if (line.Contains ("Join request"))
		{
			_netJoinRequest += 1;
			CreateLogEntry (line);
			//Debug.LogError(line);
		}
		else if (line.Contains ("Join succeeded"))
		{
			_netJoinSucceeded += 1;
			CreateLogEntry (line);
			//Debug.LogError(line);
		}
		else if (line.Contains ("UChannel::CleanUp"))
		{
			_netCleanUp += 1;
		}
		else if (line.Contains ("UNetConnection::Close"))
		{
			CreateLogEntry (line);
			_netCleanUp += 1;
		}
		else if (line.Contains ("LocalNetworkVersion"))
		{
			_netLocalNetworkVersion += 1;
		}
		else if (line.Contains ("NotifyAcceptingChannel"))
		{
			_netLocalNetworkVersion += 1;
		}
		else
		{
			_netOthers += 1;
			//Debug.LogWarning (line);
		}

	}
	void ProcessLoginDisplay (string line)
	{
		if (line.Contains ("Picking player start"))
		{
		}
		else if(line.Contains("non-ADHOC PlayerStart points"))
		{
		}
		else
		{
			CreateLogEntry (line);
		}
	}

	private void CreateScrollviewEntry(string entry)
	{
		_log += entry;

		GameObject obj = Instantiate (_logOutputPrefab);
		if (obj)
		{
			_childrenList.Add (obj);
			LogOutputPrefab script = obj.GetComponent<LogOutputPrefab> ();
			script.transform.SetParent (_logContentPanel);
			if (script)
				script._text.text = entry;
		}
	}

	private void CreateLogEntry(string line)
	{
		string fileName = "PROCESSED_LOG.txt";
		if (!File.Exists(fileName)) 
		{
			// Create a file to write to.
			using (StreamWriter sw = File.CreateText(fileName)) 
			{
				sw.WriteLine(line);
			}	
		}
		using (StreamWriter sw = File.AppendText(fileName)) 
		{
			sw.WriteLine(line);
		}
	}
}